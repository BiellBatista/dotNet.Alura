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
        });
    }
}

var carrinho = new Carrinho();
