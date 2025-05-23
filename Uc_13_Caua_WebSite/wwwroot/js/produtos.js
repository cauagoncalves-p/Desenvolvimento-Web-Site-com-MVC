document.addEventListener('DOMContentLoaded', () => {
  const produtosLoja = [
      // Toucas
      {
          image: '/imagens/imagens-produtos/TOUCA-PRIMITIVE-WORLD/touca-primitive-world-wide-camo.png',
          imagem1: '/imagens/imagens-produtos/TOUCA-PRIMITIVE-WORLD/imagemDemostracao1.png',
          imagemDemostracao1: '/imagens/imagens-produtos/TOUCA-PRIMITIVE-WORLD/imagemDemostracao1.png',
          imagemDemostracao2: '/imagens/imagens-produtos/TOUCA-PRIMITIVE-WORLD/imagemDemostracao2.png',
          imagemDemostracao3: '/imagens/imagens-produtos/TOUCA-PRIMITIVE-WORLD/touca-primitive-world-wide-camo.png',
          textoAlternativo: 'Touca Primitive World Wide Camo',
          classificacao: 'lançamento',
          titulo: 'Touca Primitive World Wide - Camo',
          preco: 'R$ 150,00',
          precoDesconto: 'R$ 150,00',
          parcelamento: 'ou 6x de R$ 25,00 sem juros',
          descricao: 'A Touca Primitive World Wide Camo oferece estilo e conforto para os dias frios. Feita com materiais de alta qualidade, apresenta estampa camuflada moderna e ajuste perfeito para complementar qualquer visual urbano.'
      },
      {
          image: '/imagens/imagens-produtos/TOUCA-PRIMITIVE-GOOD/touca_primitive_good_for_life_vermelha.png',
          imagem1: '/imagens/imagens-produtos/TOUCA-PRIMITIVE-GOOD/imagemDemostracao1.png',
          imagemDemostracao1: '/imagens/imagens-produtos/TOUCA-PRIMITIVE-GOOD/imagemDemostracao1.png',
          imagemDemostracao2: '/imagens/imagens-produtos/TOUCA-PRIMITIVE-GOOD/imagemDemostracao2.png',
          imagemDemostracao3: '/imagens/imagens-produtos/TOUCA-PRIMITIVE-GOOD/touca_primitive_good_for_life_vermelha.png',
          textoAlternativo: 'Touca Primitive Good for Life Vermelha',
          classificacao: 'lançamento',
          titulo: 'Touca Primitive Good for Life - Vermelha',
          preco: 'R$ 150,00',
          precoDesconto: 'R$ 150,00',
          parcelamento: 'ou 6x de R$ 25,00 sem juros',
          descricao: 'A Touca Primitive Good for Life Vermelha combina design clássico com um toque vibrante. Ideal para os dias frios, ela proporciona aquecimento e adiciona personalidade ao look dos amantes do skate.'
      },
      // Camisetas
      {
          image: '/imagens/imagens-produtos/CAMISETA-THRASHER/camiseta_thrasher_preta.png',
          imagem1: '/imagens/imagens-produtos/CAMISETA-THRASHER/imagemDemostracao1.png',
          imagemDemostracao1: '/imagens/imagens-produtos/CAMISETA-THRASHER/imagemDemostracao1.png',
          imagemDemostracao2: '/imagens/imagens-produtos/CAMISETA-THRASHER/imagemDemostracao2.png',
          imagemDemostracao3: '/imagens/imagens-produtos/CAMISETA-THRASHER/camiseta_thrasher_preta.png',
          textoAlternativo: 'Camiseta Thrasher Preta',
          classificacao: 'lançamento',
          titulo: 'Camiseta Thrasher Logo - Preta',
          preco: 'R$ 129,90',
          precoDesconto: 'R$ 116,91',
          parcelamento: 'ou 5x de R$ 23,38 sem juros',
          descricao: 'A Camiseta Thrasher Logo Preta é um ícone para skatistas. Confeccionada em algodão de alta qualidade, apresenta o clássico logo da Thrasher, garantindo conforto e autenticidade para o dia a dia ou para as pistas.'
      },
      {
          image: '/imagens/imagens-produtos/CAMISETA-ELEMENTE-BRANCA/camiseta_element_branca.png',
          imagem1: '/imagens/imagens-produtos/CAMISETA-ELEMENTE-BRANCA/imagemDemostracao1.png',
          imagemDemostracao1: '/imagens/imagens-produtos/CAMISETA-ELEMENTE-BRANCA/imagemDemostracao1.png',
          imagemDemostracao2: '/imagens/imagens-produtos/CAMISETA-ELEMENTE-BRANCA/imagemDemostracao2.png',
          imagemDemostracao3: '/imagens/imagens-produtos/CAMISETA-ELEMENTE-BRANCA/camiseta_element_branca.png',
          textoAlternativo: 'Camiseta Element Branca',
          classificacao: 'lançamento',
          titulo: 'Camiseta Element Vertical - Branca',
          preco: 'R$ 99,90',
          precoDesconto: 'R$ 89,91',
          parcelamento: 'ou 4x de R$ 22,48 sem juros',
          descricao: 'A Camiseta Element Vertical Branca oferece um design clean com o logotipo estampado verticalmente. Seu tecido leve e respirável garante conforto para as sessões de skate e momentos casuais.'
      },
      // Shapes
      {
          image: '/imagens/imagens-produtos/SHAPE-FLIP/shape_flip_hkd.png',
          imagem1: '/imagens/imagens-produtos/SHAPE-FLIP/imagemDemostracao1.png',
          imagemDemostracao1: '/imagens/imagens-produtos/SHAPE-FLIP/imagemDemostracao1.png',
          imagemDemostracao2: '/imagens/imagens-produtos/SHAPE-FLIP/imagemDemostracao2.png',
          imagemDemostracao3: '/imagens/imagens-produtos/SHAPE-FLIP/shape_flip_hkd.png',
          textoAlternativo: 'Shape Flip HKD',
          classificacao: 'lançamento',
          titulo: 'Shape Flip HKD 8.0"',
          preco: 'R$ 349,90',
          precoDesconto: 'R$ 314,91',
          parcelamento: 'ou 6x de R$ 52,48 sem juros',
          descricao: 'O Shape Flip HKD 8.0" é ideal para skatistas que buscam desempenho e durabilidade. Fabricado com maple canadense de alta qualidade, oferece resistência, pop e precisão em cada manobra técnica.'
      },
      {
          image: '/imagens/imagens-produtos/SHAPE-BAKER/shape_baker_brand_logo.png',
          imagem1: '/imagens/imagens-produtos/SHAPE-BAKER/imagemDemostracao1.png',
          imagemDemostracao1: '/imagens/imagens-produtos/SHAPE-BAKER/imagemDemostracao1.png',
          imagemDemostracao2: '/imagens/imagens-produtos/SHAPE-BAKER/imagemDemostracao2.png',
          imagemDemostracao3: '/imagens/imagens-produtos/SHAPE-BAKER/shape_baker_brand_logo.png',
          textoAlternativo: 'Shape Baker Brand Logo',
          classificacao: 'lançamento',
          titulo: 'Shape Baker Brand Logo 8.25"',
          preco: 'R$ 379,90',
          precoDesconto: 'R$ 341,91',
          parcelamento: 'ou 6x de R$ 56,98 sem juros',
          descricao: 'O Shape Baker Brand Logo 8.25" exibe o clássico logo da Baker e é fabricado com maple de alta resistência. Proporciona excelente controle e estabilidade, atendendo às exigências dos skatistas mais experientes.'
      },
      // Lixas
      {
          image: '/imagens/imagens-produtos/LIXA-GRIZZLY/lixa_grizzly_basic.png',
          imagem1: '/imagens/imagens-produtos/LIXA-GRIZZLY/imagemDemostracao1.png',
          imagemDemostracao1: '/imagens/imagens-produtos/LIXA-GRIZZLY/imagemDemostracao1.png',
          imagemDemostracao2: '/imagens/imagens-produtos/LIXA-GRIZZLY/imagemDemostracao2.png',
          imagemDemostracao3: '/imagens/imagens-produtos/LIXA-GRIZZLY/lixa_grizzly_basic.png',
          textoAlternativo: 'Lixa Grizzly Basic',
          classificacao: 'lançamento',
          titulo: 'Lixa de Skate Importada Grizzly Basic',
          preco: 'R$ 69,90',
          precoDesconto: 'R$ 66,41',
          parcelamento: 'ou 4x de R$ 17,48 sem juros',
          descricao: 'A Lixa Grizzly Basic é reconhecida pela durabilidade e aderência superior. Seu design clássico garante o controle necessário para executar manobras com precisão e segurança durante as sessões de skate.'
      },
      {
          image: '/imagens/imagens-produtos/LIXA-JESSUP/lixa_jessup.png',
          imagem1: '/imagens/imagens-produtos/LIXA-JESSUP/imagemDemostracao1.png',
          imagemDemostracao1: '/imagens/imagens-produtos/LIXA-JESSUP/imagemDemostracao1.png',
          imagemDemostracao2: '/imagens/imagens-produtos/LIXA-JESSUP/imagemDemostracao2.png',
          imagemDemostracao3: '/imagens/imagens-produtos/LIXA-JESSUP/lixa_jessup.png',
          textoAlternativo: 'Lixa Jessup',
          classificacao: 'lançamento',
          titulo: 'Lixa de Skate Importada Jessup',
          preco: 'R$ 69,90',
          precoDesconto: 'R$ 66,40',
          parcelamento: 'ou 3x de R$ 23,30 sem juros',
          descricao: 'A Lixa Jessup é uma das preferidas entre os profissionais do skate. Proporciona tração consistente e é fácil de aplicar, garantindo que seus pés se mantenham firmes e seguros em cada manobra.'
      },
      // Acessórios
      {
          image: '/imagens/imagens-produtos/CHAVE-T/chave_t.png',
          imagem1: '/imagens/imagens-produtos/CHAVE-T/imagemDemostracao1.png',
          imagemDemostracao1: '/imagens/imagens-produtos/CHAVE-T/imagemDemostracao1.png',
          imagemDemostracao2: '/imagens/imagens-produtos/CHAVE-T/imagemDemostracao2.png',
          imagemDemostracao3: '/imagens/imagens-produtos/CHAVE-T/chave_t.png',
          textoAlternativo: 'Chave T para Skate',
          classificacao: 'lançamento',
          titulo: 'Chave T Multiuso para Skate',
          preco: 'R$ 49,90',
          precoDesconto: 'R$ 44,91',
          parcelamento: 'ou 2x de R$ 22,45 sem juros',
          descricao: 'A Chave T Multiuso é essencial para ajustes rápidos no seu skate. Compacta e eficiente, permite a manutenção dos trucks, rodas e parafusos, mantendo seu equipamento sempre pronto para as manobras.'
      },
      {
          image: '/imagens/imagens-produtos/MOCHILA-NIKE/mochila_nike_sb.png',
          imagem1: '/imagens/imagens-produtos/MOCHILA-NIKE/imagemDemostracao1.png',
          imagemDemostracao1: '/imagens/imagens-produtos/MOCHILA-NIKE/imagemDemostracao1.png',
          imagemDemostracao2: '/imagens/imagens-produtos/MOCHILA-NIKE/imagemDemostracao2.png',
          imagemDemostracao3: '/imagens/imagens-produtos/MOCHILA-NIKE/mochila_nike_sb.png',
          textoAlternativo: 'Mochila Nike SB',
          classificacao: 'lançamento',
          titulo: 'Mochila Nike SB Courthouse',
          preco: 'R$ 299,90',
          precoDesconto: 'R$ 269,91',
          parcelamento: 'ou 5x de R$ 53,98 sem juros',
          descricao: 'A Mochila Nike SB Courthouse foi projetada para transportar seu skate e acessórios com segurança. Com compartimentos bem distribuídos e alças confortáveis, une estilo e praticidade para o dia a dia.'
      },
      // Rodas
      {
          image: '/imagens/imagens-produtos/RODAS-BONES/rodas_bones_100s.png',
          imagem1: '/imagens/imagens-produtos/RODAS-BONES/imagemDemostracao1.png',
          imagemDemostracao1: '/imagens/imagens-produtos/RODAS-BONES/imagemDemostracao1.png',
          imagemDemostracao2: '/imagens/imagens-produtos/RODAS-BONES/imagemDemostracao2.png',
          imagemDemostracao3: '/imagens/imagens-produtos/RODAS-BONES/rodas_bones_100s.png',
          textoAlternativo: 'Rodas Bones 100s',
          classificacao: 'lançamento',
          titulo: 'Rodas Bones 100s 52mm',
          preco: 'R$ 259,90',
          precoDesconto: 'R$ 233,91',
          parcelamento: 'ou 5x de R$ 51,98 sem juros',
          descricao: 'As Rodas Bones 100s 52mm são desenvolvidas para oferecer velocidade e durabilidade. Com precisão de balanceamento e materiais premium, garantem uma performance estável e eficaz em pistas e ruas.'
      },
      {
          image: '/imagens/imagens-produtos/RODAS-SPITFIRE/rodas_spitfire_classic.png',
          imagem1: '/imagens/imagens-produtos/RODAS-SPITFIRE/imagemDemostracao1.png',
          imagemDemostracao1: '/imagens/imagens-produtos/RODAS-SPITFIRE/imagemDemostracao1.png',
          imagemDemostracao2: '/imagens/imagens-produtos/RODAS-SPITFIRE/imagemDemostracao2.png',
          imagemDemostracao3: '/imagens/imagens-produtos/RODAS-SPITFIRE/rodas_spitfire_classic.png',  
          textoAlternativo: 'Rodas Spitfire Classic',
          classificacao: 'lançamento',
          titulo: 'Rodas Spitfire Classic 53mm',
          preco: 'R$ 279,90',
          precoDesconto: 'R$ 251,91',
          parcelamento: 'ou 5x de R$ 55,98 sem juros',
          descricao: 'As Rodas Spitfire Classic 53mm combinam estilo e resistência. Produzidas com materiais de alta qualidade, oferecem tração e estabilidade superiores, ideais para quem busca performance em cada manobra.'
      },
      // Trucks
      {
          image: '/imagens/imagens-produtos/TRUCK-INDEPENDENT/truck_independent_stage_11.png',
          imagem1: '/imagens/imagens-produtos/TRUCK-INDEPENDENT/imagemDemostracao1.png',
          imagemDemostracao1: '/imagens/imagens-produtos/TRUCK-INDEPENDENT/imagemDemostracao1.png',
          imagemDemostracao2: '/imagens/imagens-produtos/TRUCK-INDEPENDENT/imagemDemostracao2.png',
          imagemDemostracao3: '/imagens/imagens-produtos/TRUCK-INDEPENDENT/truck_independent_stage_11.png',
          textoAlternativo: 'Truck Independent Stage 11',
          classificacao: 'lançamento',
          titulo: 'Truck Independent Stage 11 139mm',
          preco: 'R$ 499,90',
          precoDesconto: 'R$ 449,91',
          parcelamento: 'ou 6x de R$ 74,98 sem juros',
          descricao: 'O Truck Independent Stage 11 139mm é sinônimo de robustez e precisão. Fabricado com materiais resistentes, oferece excelente desempenho e estabilidade, sendo ideal para skatistas que exigem qualidade nas manobras.'
      },
      {
          image: '/imagens/imagens-produtos/TRUCK-THUNDER-POLISHED/truck_thunder_polished.png',
          imagem1: '/imagens/imagens-produtos/TRUCK-THUNDER-POLISHED/imagemDemostracao1.png',
          imagemDemostracao1: '/imagens/imagens-produtos/TRUCK-THUNDER-POLISHED/imagemDemostracao1.png',
          imagemDemostracao2: '/imagens/imagens-produtos/TRUCK-THUNDER-POLISHED/imagemDemostracao2.png',
          imagemDemostracao3: '/imagens/imagens-produtos/TRUCK-THUNDER-POLISHED/truck_thunder_polished.png',
          textoAlternativo: 'Truck Thunder Polished',
          classificacao: 'lançamento',
          titulo: 'Truck Thunder Polished 147mm',
          preco: 'R$ 479,90',
          precoDesconto: 'R$ 431,91',
          parcelamento: 'ou 6x de R$ 71,98 sem juros',
          descricao: 'O Truck Thunder Polished 147mm une design sofisticado e alta performance. Com acabamento polido e construção robusta, proporciona estabilidade e controle excepcionais, ideal para manobras radicais e uso prolongado.'
      }
  ];
    const produtosGrid = document.querySelector('.aba-produtos');

    produtosLoja.forEach(prod => {
        const produtosCard = document.createElement('div');
        produtosCard.classList.add('card-produtos');

        produtosCard.innerHTML = `
                <div class="card-imagem">
                    <img src="${prod.image}" alt="${prod.textoAlternativo}">
                    <div class="card-imagem-hover">
                        <img src="${prod.imagem1}" alt="${prod.textoAlternativo}">
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
              <button class="botao-cardProdutos" onclick="verProduto('${encodeURIComponent(prod.titulo)}', '${encodeURIComponent(prod.preco)}', '${encodeURIComponent(prod.precoDesconto)}', '${encodeURIComponent(prod.image)}','${encodeURIComponent(prod.parcelamento)}', '${encodeURIComponent(prod.descricao)}', '${encodeURIComponent(prod.textoAlternativo)}', '${encodeURIComponent(prod.imagemDemostracao1)}', '${encodeURIComponent(prod.imagemDemostracao2)}', '${encodeURIComponent(prod.imagemDemostracao3)}')">Ver Produto</button>
          `;

        produtosGrid.appendChild(produtosCard);
    });
});

function verProduto(nome, preco, precoDesconto, imagem, parcelamento, descricao, textoAlternativo, imagemDemostracao1, imagemDemostracao2, imagemDemostracao3) {
    // Corrigindo o formato da URL
    const url = `/Home/VerProduto?nome=${encodeURIComponent(nome)}&preco=${encodeURIComponent(preco)}&precoDesconto=${encodeURIComponent(precoDesconto)}&imagem=${encodeURIComponent(imagem)}&parcelamento=${encodeURIComponent(parcelamento)}&descricao=${encodeURIComponent(descricao)}&textoAlternativo=${encodeURIComponent(textoAlternativo)}&imagemDemostracao1=${encodeURIComponent(imagemDemostracao1)}&imagemDemostracao2=${encodeURIComponent(imagemDemostracao2)}&imagemDemostracao3=${encodeURIComponent(imagemDemostracao3)}`;

    window.location.href = url;
}

// função para abrir a opção de filtros da pagina de skate
const dropdownBtn = document.querySelector('.dropdown-btn');
const dropdownMenu = document.querySelector('.dropdown-menu-filter');
const arrow = document.querySelector('.arrow');
const selectedText = document.getElementById('selected-option');

dropdownBtn.addEventListener('click', () => {
    dropdownMenu.classList.toggle('show');
});

function selectOption(option) {
    selectedText.textContent = option;
    dropdownMenu.classList.remove('show');
}

// Fecha o dropdown se clicar fora dele
document.addEventListener('click', (event) => {
    if (!dropdownBtn.contains(event.target) && !dropdownMenu.contains(event.target)) {
        dropdownMenu.classList.remove('show');
    }
});


// Função que mostra as opções de filtros na tela
const botoes = document.querySelectorAll('.verMais');

botoes.forEach(botao => {
    const Textobotao = botao.textContent;

    botao.addEventListener('click', () => {
        const container = botao.closest('.checkbox, .categoria');
        const labels = container.querySelectorAll('.label-grup-none');

        labels.forEach(label => {
            label.classList.toggle('hidden');
        });

        if (botao.textContent === Textobotao) {
            botao.textContent = "Ver menos";
        } else {
            botao.textContent = Textobotao;
        }
    });
});
// Elementos do modal
const modal = document.getElementById('atendimentoModal');
const openModal = document.getElementById('openModal');
const closeBtn = document.getElementById('closeBtn');

// Abre o modal ao clicar no botão
openModal.addEventListener('click', () => {
    modal.classList.add('ativo');
});

// Fecha o modal ao clicar no "X"
closeBtn.addEventListener('click', () => {
    modal.classList.remove('ativo');
});

// Fecha o modal ao clicar fora da área do conteúdo
window.addEventListener('click', (event) => {
    if (event.target === modal) {
        modal.classList.remove('ativo');
    }
});

// Menu dropdown
const menu = document.querySelector('.user-menu');
const menudropdown = document.querySelector('.dropdown-menu');

menu.addEventListener('click', (event) => {
    event.stopPropagation(); // Impede que o clique no menu propague para o window
    menudropdown.classList.toggle('active');
});

window.addEventListener('click', (event) => {
    if (event.target !== menu && !menudropdown.contains(event.target)) {
        menudropdown.classList.remove('active');
    }
});
