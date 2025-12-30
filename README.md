# 🕹️ Start 2D

Um jogo de plataforma clássico em estilo Pixel Art desenvolvido na Unity. O projeto foca em mecânicas fundamentais de jogabilidade, persistência de dados entre cenas e uma interface de utilizador (UI) intuitiva.

---

## 📝 Descrição do Projeto
Este jogo desafia o jogador a atravessar níveis repletos de obstáculos como espinhos e plataformas que caem. O jogador deve gerir as suas vidas e acumular a maior pontuação possível enquanto avança para o nível final.

---

## 🚀 Como Executar

1.  **Pré-requisitos**: Ter o **Unity Hub** instalado com a versão **2022.3 LTS** ou superior.
2.  **Clonagem**:
    ```
    git clone https://github.com/RonaldRonan14/Jogo-de-Plataforma-2D.git
    ```
3.  **Configuração na Unity**:
    - Adicione o projeto ao Unity Hub.
    - Vá a `File > Build Settings` e certifique-se de que todas as cenas em `Assets/Scenes` estão na lista (Menu em 0, Level 1 em 1, etc.).
4.  **Play**: Abra a cena de Menu e clique no botão **Play**.

---

## 🕹️ Mecânicas e Funcionalidades

### 🏃 Movimentação e Física
- **Controlo Preciso**: Movimentação lateral e pulo com detecção de colisão contínua para evitar falhas em alta velocidade.

### 💖 Sistema de Vidas e Pontuação
- **Vidas**: O jogador possui 3 vidas representadas por ícones de coração na UI.
- **Persistência de Score**: A pontuação é mantida através de variáveis estáticas ao mudar de nível.
- **Game Over**: Ao perder todas as vidas, o jogo pausa (`Time.timeScale = 0`) e exibe um painel de reinicialização que limpa o progresso.

### 🔊 Sistema de Áudio (AudioManager)
- Gerenciamento centralizado de sons através de um **Singleton**.
- Suporte para efeitos de: **Pulo, Coleta de Itens, Dano e Game Over**.
- Áudio configurado em modo 2D para consistência sonora em todo o mapa.

---

## 🎮 Controles

| Ação | Tecla / Comando |
| :--- | :--- |
| **Mover para Esquerda/Direita** | `Setas` ou `A / D` |
| **Pular** | `Espaço` |
| **Cursor Personalizado** | Ativo automaticamente em botões |

---

## 🛠️ Scripts Principais

1.  **`GameController.cs`**: O "cérebro" do jogo. Controla a pontuação acumulada, a lista de corações (UI) e o estado do Game Over.
2.  **`Player.cs`**: Responsável pela física do personagem e disparo de eventos de áudio.
3.  **`AudioManager.cs`**: Centraliza todos os `AudioClips` e utiliza `PlayOneShot` para evitar sobreposição de áudio.
4.  **`EndLevel.cs`**: Verifica dinamicamente se existe uma próxima cena no Build Index ou se deve exibir o painel de vitória.
5.  **`DeathZone.cs`**: Gerencia o *Respawn* do jogador, ocultando o visual do personagem durante a transição sonora de morte.

---

## 🎨 Aspectos Técnicos de Arte
- **Texturas**: Configuradas com `Filter Mode: Point (no filter)` para garantir a nitidez do pixel art.
- **UI**: Uso de `Canvas Groups` para transições de transparência e `TextMeshPro` para textos.

---

## 👨‍💻 Autor
Desenvolvido por **Ronald Ronan Galeno Brito** como projeto de estudo em Unity 2D.
