document.addEventListener('DOMContentLoaded', () => {
    const produtosLoja = [
        {
            image: '/imagens/imagens-home/skate/skate.png',
            imagem1: '/imagens/imagens-home/skate/imagemDemostracao1.png',
            imagemDemostracao1: '/imagens/imagens-home/skate/imagemDemostracao1.png',
            imagemDemostracao2: '/imagens/imagens-home/skate/imagemDemostracao2.png',
            textoAlternativo: 'shape skate',
            classificacao: 'lançamento',
            titulo: 'Shape DarkStar Whip Red',
            preco: 'R$369,99',
            precoDesconto: 'R$297,99',
            parcelamento: 'ou 6x de R$49,67 sem juros',
            descricao: 'Shape profissional em maple canadense com design vibrante.'
        },
        {
            image: '/imagens/imagens-home/tenisFreeday/tenis1.png',
            imagem1: '/imagens/imagens-home/tenisFreeday/imagemDemostracao1.png',
            imagemDemostracao1: '/imagens/imagens-home/tenisFreeday/imagemDemostracao1.png',
            imagemDemostracao2: '/imagens/imagens-home/tenisFreeday/imagemDemostracao2.png',
            imagemDemostracao3: '/imagens/imagens-home/tenisFreeday/imagemDemostracao3.png',
            textoAlternativo: 'tênis de skate',
            classificacao: 'lançamento',
            titulo: 'Tênis Freeday Hero Preto Azul',
            preco: 'R$399,99',
            precoDesconto: 'R$347,99',
            parcelamento: 'ou 10x de R$34,70 sem juros',
            descricao: 'Tênis com design moderno para manobras radicais.'
        },
        {
            image: '/imagens/imagens-home/truck/truck-venture.png',
            imagem1: '/imagens/imagens-home/truck/imagemDemostracao1.png',
            imagemDemostracao1: '/imagens/imagens-home/truck/imagemDemostracao1.png',
            imagemDemostracao2: '/imagens/imagens-home/truck/imagemDemostracao2.png',
            imagemDemostracao3: '/imagens/imagens-home/truck/imagemDemostracao3.png',
            textoAlternativo: 'truck venture',
            classificacao: 'lançamento',
            titulo: 'Truck Venture Gilbert Crockett',
            preco: 'R$599,90',
            precoDesconto: 'R$539,90',
            parcelamento: 'ou 6x de R$89,98 sem juros',
            descricao: 'Truck profissional para alta performance.'
        },
        {
            image: '/imagens/imagens-home/roda/roda-skate.png',
            imagem1: '/imagens/imagens-home/roda/imagemDemostracao1.png',
            imagemDemostracao1: '/imagens/imagens-home/roda/imagemDemostracao1.png',
            imagemDemostracao2: '/imagens/imagens-home/roda/imagemDemostracao2.png',
            imagemDemostracao3: '/imagens/imagens-home/roda/imagemDemostracao3.png',
            textoAlternativo: 'roda de skate',
            classificacao: 'lançamento',
            titulo: 'Roda Ricta Speedrings Wide 54mm',
            preco: 'R$449,90',
            precoDesconto: 'R$409,90',
            parcelamento: '6x de R$68,32 sem juros',
            descricao: 'Roda com excelente tração e durabilidade.'
        },
        {
            image: '/imagens/imagens-home/SkateMontado/skate1.png',
            imagem1: '/imagens/imagens-home/SkateMontado/imagemDemostracao3.png',
            imagemDemostracao1: '/imagens/imagens-home/SkateMontado/imagemDemostracao1.png',
            imagemDemostracao2: '/imagens/imagens-home/SkateMontado/imagemDemostracao2.png',
            imagemDemostracao3: '/imagens/imagens-home/SkateMontado/imagemDemostracao3.png',
            textoAlternativo: 'skate completo',
            classificacao: 'lançamento',
            titulo: 'Skate Montado CBGANG Mais Pilaco',
            preco: 'R$279,99',
            precoDesconto: 'R$129,99',
            parcelamento: '6x de R$21,59 sem juros',
            descricao: 'Skate completo pronto para uso.'
        }
    ];

    const renderizarProdutos = () => {
        const produtosGrid = document.querySelector('.aba-produtos');
        if (!produtosGrid) return;

        produtosGrid.innerHTML = produtosLoja.map(prod => `
      <div class="card-produtos">
        <div class="card-imagem">
          <img src="${prod.image}" alt="${prod.textoAlternativo}" loading="lazy">
          <div class="card-imagem-hover">
            <img src="${prod.imagem1}" alt="${prod.textoAlternativo}" loading="lazy">
          </div>
        </div>
        <div class="info-produtos">
          <h4>${prod.classificacao}</h4>
          <h3>${prod.titulo.toUpperCase()}</h3>
          <div class="precos">
            <span>${prod.preco}</span>
            <p>${prod.precoDesconto}</p>
          </div>
          <p class="parcelamento">${prod.parcelamento}</p>
        </div>
        <button class="botao-cardProdutos" onclick="verProduto(${JSON.stringify(prod).replace(/"/g, '&quot;')})">
          Ver Produto
        </button>
      </div>
    `).join('');
    };

    window.verProduto = (produto) => {
        const params = new URLSearchParams();
        Object.entries(produto).forEach(([key, value]) => {
            params.append(key, value);
        });
        window.location.href = `/Home/VerProduto?${params.toString()}`;
    };

    // Modal de atendimento
    const modal = document.getElementById('atendimentoModal');
    const openModal = document.getElementById('openModal');
    const closeBtn = document.getElementById('closeBtn');

    if (modal && openModal && closeBtn) {
        openModal.addEventListener('click', () => {
            modal.classList.add('ativo');
        });

        closeBtn.addEventListener('click', () => {
            modal.classList.remove('ativo');
        });

        window.addEventListener('click', (event) => {
            if (event.target === modal) {
                modal.classList.remove('ativo');
            }
        });
    }

    // Menu dropdown
    const menu = document.querySelector('.user-menu');
    const menudropdown = document.querySelector('.dropdown-menu');

    if (menu && menudropdown) {
        menu.addEventListener('click', (event) => {
            event.stopPropagation();
            menudropdown.classList.toggle('active');
        });

        window.addEventListener('click', () => {
            menudropdown.classList.remove('active');
        });
    }

    renderizarProdutos();
});