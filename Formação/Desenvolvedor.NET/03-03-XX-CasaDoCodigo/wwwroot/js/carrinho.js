class Carrinho {
    clickIncremento(btn) {
        let data = this.getData(btn);
        data.Quantidade++;
        this.postQuantidade(data);

        //$(seletor).action(); o seletor significa a tag que quero manipular
        /*
         * Isso mesmo! O método parents obtém os "ancestrais" (elementos acima da hierarquia) do elemento. O método find vai obter os elementos abaixo da hiearquia.
         */
    }

    clickDecremento(btn) {
        let data = this.getData(btn);
        data.Quantidade--;
        this.postQuantidade(data);
    }

    updateQuantidade(input) {
        let data = this.getData(input);
        this.postQuantidade(data);
    }

    getData(elemento) {
        let linhaeItem = $(elemento).parents('[item-id]'); //pegando
        let itemId = $(linhaeItem).attr('item-id'); //pegando o valor do atributo item-id
        let novaQtde = $(linhaeItem).find('input').val(); //acessando o valor de uma tag abaixo da tag que tem o atributo ['item-id']
        let data = {
            Id: itemId,
            Quantidade: novaQtde
        };

        return data;
    }

    postQuantidade(data) {
        $.ajax({
            url: '/pedido/updatequantidade',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data)
        }).done(function (response) { //quando o ajax for concluido. Faça..
            let itemPedido = response.itemPedido;
            let linhaDoItem = $(`[item-id=${itemPedido.id}]`); //pegando uma tag pelo seu atributo. Nesse caso é um elemento DIV
            linhaDoItem.find('input').val(itemPedido.quantidade); //procurando a tag input dentro da linhaDoItem (tag DIV)
            linhaDoItem.find('[subtotal]').html((itemPedido.subTotal).duasCasas()); //localizando uma tag pelo atributo e depois alterando o HTML (posso usar o método HTML() para elementos que podem conter html, como body, div e span)

            let carrinhoViewModel = response.carrinhoViewModel;
            $('[numero-itens]').html(`Total: ${carrinhoViewModel.itens.length} itens`);
            $('[total]').html(`${(carrinhoViewModel.total).duasCasas()}`);

            if (itemPedido.quantidade === 0) {
                linhaDoItem.remove();
            }
        });
    }
}

var carrinho = new Carrinho();

Number.prototype.duasCasas = function () {
    return this.toFixed(2).replace('.', ',');
}
