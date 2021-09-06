using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace _05_02_XX_Coletando_Lixo.Antes
{
    public class MensageiroNotepad2
    {
        private IntPtr ponteiroNotepad;

        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        public void EnviarMensagem(string mensagem)
        {
            //Obtém os processos do Windows que estão rodando instâncias do Notepad
            Process[] notepads = Process.GetProcessesByName("notepad");

            if (notepads.Length == 0) return;

            if (notepads[0] != null)
            {
                //Se uma janela do Notepad estiver aberta, obtém o ponteiro para essa janela
                ponteiroNotepad = FindWindowEx(notepads[0].MainWindowHandle, new IntPtr(0), "Edit", null);
                //Envia para o Notepad (através do ponteiro) a mensagem digitada
                SendMessage(ponteiroNotepad, 0x000C, 0, mensagem);
            }
        }

        ~MensageiroNotepad2()
        {
            //Descarta os recursos não-gerenciados:
            CloseHandleEx(Process.GetCurrentProcess().Handle, ponteiroNotepad);
            ponteiroNotepad = IntPtr.Zero;
        }

        private const uint PROCESS_DUP_HANDLE = 0x0040;

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess,
            [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, IntPtr dwProcessId);

        [Flags]
        private enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VMOperation = 0x00000008,
            VMRead = 0x00000010,
            VMWrite = 0x00000020,
            DupHandle = 0x00000040,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            Synchronize = 0x00100000
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DuplicateHandle(IntPtr hSourceProcessHandle,
           IntPtr hSourceHandle, IntPtr hTargetProcessHandle, out IntPtr lpTargetHandle,
           uint dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, DuplicateOptions dwOptions);

        [Flags]
        private enum DuplicateOptions : uint
        {
            DUPLICATE_CLOSE_SOURCE = (0x00000001),
            DUPLICATE_SAME_ACCESS = (0x00000002),
        }

        public static bool CloseHandleEx(IntPtr pid, IntPtr handle)
        {
            IntPtr hProcess = OpenProcess(ProcessAccessFlags.DupHandle, false, pid);
            IntPtr dupHandle = IntPtr.Zero;
            bool success = DuplicateHandle(hProcess, handle, IntPtr.Zero, out dupHandle, 0, false, DuplicateOptions.DUPLICATE_CLOSE_SOURCE);
            CloseHandle(hProcess);

            return success;
        }
    }
}