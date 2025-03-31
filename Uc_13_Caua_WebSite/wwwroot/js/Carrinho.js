document.addEventListener('DOMContentLoaded', () => {
    updateCartUI();

    // Configuração do botão comprar
    const btnComprar = document.querySelector('.btn-produto');
    if (btnComprar) {
        btnComprar.addEventListener('click', addCurrentProductToCart);
    }

    // Botão voltar
    const botaoVoltar = document.querySelector('#voltar');
    if (botaoVoltar) {
        botaoVoltar.addEventListener('click', () => window.history.back());
    }
});

// Adiciona o produto atual ao carrinho
function addCurrentProductToCart() {
    const produto = {
        name: document.querySelector('.info-produto h3').textContent,
        details: document.querySelector('.discricao-produto p').textContent,
        price: parseFloat(document.querySelector('.precos-produto p:first-child').textContent
            .replace('R$ ', '').replace(',', '.')),
        discountPrice: parseFloat(document.querySelector('.precos-produto p:last-child').textContent
            .replace('R$ ', '').replace(',', '.')),
        img: document.querySelector('#imagemProduto').src,
        quantidade: 1
    };

    addToCart(produto);
}

// Função para adicionar ao carrinho
function addToCart(product) {
    let cart = JSON.parse(localStorage.getItem('cart')) || [];
    const existingProduct = cart.find(p => p.name === product.name);

    if (existingProduct) {
        existingProduct.quantidade += 1;
    } else {
        cart.push(product);
    }

    localStorage.setItem('cart', JSON.stringify(cart));
    updateCartUI();
    alert('Produto adicionado ao carrinho!');

    // Abre o carrinho automaticamente
    const offcanvas = new bootstrap.Offcanvas(document.getElementById('offcanvasRight'));
    offcanvas.show();
}

// Atualiza a interface do carrinho
function updateCartUI() {
    const cart = JSON.parse(localStorage.getItem('cart')) || [];
    const cartList = document.getElementById('cart-list');
    const itemCount = document.getElementById('cart-item-count');
    const subtotalDisplay = document.getElementById('cart-subtotal');
    const cartCountBadge = document.getElementById('cart-count');

    cartList.innerHTML = cart.length === 0
        ? '<p id="empty-cart-msg">Seu carrinho está vazio.</p>'
        : cart.map((product, index) => `
        <div class="produtos-adicionados">
          <div class="img-produto">
            <img src="${product.img}" alt="${product.name}" />
          </div>
          <div class="info-produto">
            <div class="titulo-info-produto">
              <p>${product.name}</p>
            </div>
            <div class="info-produto-detalhes">
              <p class="descricao">${product.details}</p>
              <button class="ver-mais">Ver Mais</button>
            </div>
            <div class="info-produto-preco">
              <span>R$ ${product.price.toFixed(2).replace('.', ',')}</span>
              <span>R$ ${product.discountPrice.toFixed(2).replace('.', ',')}</span>
            </div>
            <div class="opcoes-produto">
              <div class="remove-quantidade" onclick="decreaseQuantity(${index})">
                <i class="fa-solid fa-minus"></i>
              </div>
              <div class="quantidade-produto">
                <p>${product.quantidade}</p>
              </div>
              <div class="add-quantidade" onclick="increaseQuantity(${index})">
                <i class="fa-solid fa-plus"></i>
              </div>
              <div onclick="removeFromCart(${index})">
                <i class="fa-solid fa-trash"></i>
              </div>
            </div>
          </div>
        </div>
      `).join('');

    // Atualiza contadores
    itemCount.textContent = `Itens: ${cart.length}`;
    cartCountBadge.textContent = cart.length;
    const subtotal = cart.reduce((sum, p) => sum + (p.discountPrice * p.quantidade), 0);
    subtotalDisplay.innerHTML = `Subtotal: <strong>R$ ${subtotal.toFixed(2).replace('.', ',')}</strong>`;
}

// Funções auxiliares
function increaseQuantity(index) {
    const cart = JSON.parse(localStorage.getItem('cart')) || [];
    if (cart[index]) cart[index].quantidade += 1;
    localStorage.setItem('cart', JSON.stringify(cart));
    updateCartUI();
}

function decreaseQuantity(index) {
    const cart = JSON.parse(localStorage.getItem('cart')) || [];
    if (cart[index] && cart[index].quantidade > 1) cart[index].quantidade -= 1;
    localStorage.setItem('cart', JSON.stringify(cart));
    updateCartUI();
}

function removeFromCart(index) {
    const cart = JSON.parse(localStorage.getItem('cart')) || [];
    cart.splice(index, 1);
    localStorage.setItem('cart', JSON.stringify(cart));
    updateCartUI();
    alert('Produto removido do carrinho!');
}