# Estrutura proposta
Criar pelo Unity para gerar e preservar os .meta:

ProjetoFinal3D/Assets/_Project/
  Scenes/Tests/       # PlayerTest, EnemyTest, RulesTest
  Scenes/            # Arena: integrante 2 integra
  Scripts/Player/    # integrante 1
  Scripts/Enemies/   # integrante 2
  Scripts/Core/      # integrante 3
  Scripts/Collectibles/ # integrante 3
  Scripts/UI/        # integrante 3
  Scripts/Shared/    # contratos alinhados pelo trio
  Prefabs/Player/
  Prefabs/Enemies/
  Prefabs/Collectibles/
  Materials/
  Audio/

Ainda não há contratos C# implementados. Antes de integração, registrar assinaturas de dano, morte, derrota de inimigo e coleta, com responsáveis e regras de disparo único.
