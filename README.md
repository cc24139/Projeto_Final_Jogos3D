# Arena de Treinamento

Jogo acadêmico 3D em trio: personagem, inimigos, Game Manager, dano, coleta, pontuação e vitória.

## Abrir o projeto
Clone o repositório e, no Unity Hub, adicione a subpasta `ProjetoFinal3D`.
Use Unity **6000.3.2f1**. A versão exata está em `ProjetoFinal3D/ProjectSettings/ProjectVersion.txt`.
O projeto usa URP 17.3.0 e Input System 1.17.0; o novo sistema de entrada está ativo. Não use a API antiga UnityEngine.Input para implementar os controles.

## Organização
A raiz contém o repositório Git e a documentação. O projeto Unity fica em `ProjetoFinal3D/`.
Versione Assets com seus .meta, Packages e ProjectSettings. O .gitignore existente exclui caches e configurações locais.
A serialização de assets já está configurada como Force Text.

## Trabalho do trio
- Integrante 1: personagem, câmera, disparo, vida e dano.
- Integrante 2: arena, inimigos e integração da cena principal.
- Integrante 3: Game Manager, ondas, coleta, pontuação e interface.

Use branches por tarefa, por exemplo feature/player, feature/enemies e feature/game-manager. Atualize a main antes de começar e integre por pull request. Somente o integrante 2 edita a cena principal; use cenas de teste separadas.

## Estado e próximo marco
Projeto inicial existente, com SampleScene e scripts de tutorial. O gameplay planejado ainda não está implementado.
Leia AGENTS.md, docs/ESCOPO.md, docs/ESTRUTURA.md e docs/CONTINUIDADE.md.
Próximo marco: definir contratos compartilhados e implementar movimento e câmera na cena PlayerTest.
