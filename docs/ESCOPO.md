# Escopo compartilhado

## Confirmado pelo usuário
Arena de Treinamento em Unity. O usuário deste chat é o integrante 1.

## Base de implementação acordada no planejamento
- Terceira pessoa, uma arena pequena, movimento e disparo.
- Uma arma, munição infinita e intervalo entre tiros.
- Um tipo de inimigo: perseguição, dano por contato, derrota com dois acertos.
- Jogador: cinco pontos de vida, um de dano por contato, um segundo de invulnerabilidade após dano.
- Três ondas com dois, três e quatro inimigos; intervalo de três segundos após eliminar a onda atual.
- Cada inimigo deixa exatamente uma célula; cada coleta vale 100 pontos e ocorre uma vez.
- Células permanecem entre ondas. Vitória: nove inimigos derrotados e nove células coletadas. Máximo: 900 pontos.
- Derrota ao chegar a zero de vida. Reinício após encerramento.
- Interface: vida, onda, inimigos restantes, células e pontuação. Solicitar coleta restante após a terceira onda, se necessário.
Os valores são parâmetros iniciais de balanceamento.

## Responsabilidades
1. Personagem, câmera, disparo, vida, dano e notificação de morte.
2. Arena, inimigos, pontos de surgimento e integração da cena principal.
3. Game Manager, ondas, coletáveis, pontuação, interface e encerramento.
O personagem e os inimigos controlam a própria vida. O Game Manager controla a partida e coordena uma célula por inimigo derrotado. A coleta notifica o Game Manager uma vez.

## Fora do escopo
Multiplayer, chefes, múltiplas armas, recarga, munição limitada, inventário, habilidades e fases extras.

## Marcos
1. Criar projeto e repositório compartilhados.
2. Definir contrato técnico e sistema de entrada.
3. Integrar um personagem, um inimigo, disparo, dano, coleta, vitória, derrota e reinício em teste.
4. Completar três ondas e arena.
5. Testar e preparar apresentação.
