using System;

namespace _02_05_XX_Adicionando_Membros_Dinamicamente.Depois
{
    internal class InteropCOM : IAulaItem
    {
        public void Executar()
        {
            Type excelType = Type.GetTypeFromProgID("Excel.Application"
                , true);
            dynamic excel = Activator.CreateInstance(excelType);

            excel.Visible = true;
            excel.Workbooks.Add();

            dynamic planilha = excel.ActiveSheet;

            planilha.Cells[1, "A"] = "Alura";
            planilha.Cells[1, "B"] = "Cursos";
            planilha.Cells[2, "A"] = "Certificação";
            planilha.Cells[2, "B"] = "C#";
            planilha.Columns[1].AutoFit();
            planilha.Columns[2].AutoFit();
        }
    }
}

///<image url="$(ProjectDir)img16.png" />

/**
 * Eu consigo utilizar os componentes COM (coisas escritas em C++) e abrir aplicações. Porém, isso deve ser feito com o tipo dynamic,
 * pois está em outra linguagem. Posso usar o dynamic para acessar coisas em python ou Ruby.
 *
 * Muitos aplicativos, como por exemplo o Microsoft Office Suite, fornecem recursos de automação que são acessado via interfaces COM.

Isso também acontece com alguns dos elementos de baixo nível do sistema operacional Windows. É pouco provável que você tenha que interagir com objetos COM no seu dia-a-dia como programador, mas caso seja necessário, os tipos dinâmicos reduzem grande parte do esforço necessário para acessar os tipos de objetos expostos pelo COM.
 */