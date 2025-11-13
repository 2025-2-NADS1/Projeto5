# Pet Virtual - Aplicação C# Windows Forms

Uma aplicação de pet virtual desenvolvida em C# que simula um companheiro digital que reage ao seu cuidado diário.

## Descrição

O Pet Virtual é um programa onde você cuida de um pet digital através de check-ins diários. O pet possui diferentes estados emocionais e animações baseadas na sua interação.

## Funcionalidades

### Estados do Pet
- **Triste**: Estado padrão quando não há check-in no dia
- **Feliz**: Estado ativado após realizar o check-in diário

### Check-in Diário
- Botão para realizar check-in uma vez por dia
- Sistema detecta automaticamente a mudança de data
- Pet volta ao estado triste na passagem do dia seguinte

### Animações
- **Movimento flutuante**: Pet se move verticalmente de forma contínua
- **Velocidade variável**: 
  - Movimento lento quando triste
  - Movimento rápido quando feliz

### Persistência de Dados
- Estado do pet é salvo automaticamente
- Última data de check-in é registrada
- Dados mantidos entre execuções do programa

## Especificações Técnicas

- **Framework**: .NET Framework 4.8
- **Interface**: Windows Forms
- **Linguagem**: C# 
- **IDE**: Visual Studio 2022/2026
- **Resolução**: 400x450 pixels (janela fixa)

## Instalação e Uso

### Requisitos
- Windows 10 ou superior
- .NET Framework 4.8
- Visual Studio Community 2022 ou superior (para desenvolvimento)

### Como executar
1. Abra o arquivo `PetVirtual.sln` no Visual Studio
2. Compile o projeto (Ctrl + Shift + B)
3. Execute a aplicação (F5)
4. Coloque sua imagem `pet_apenas.png` na pasta do executável

### Estrutura de arquivos
```
PetVirtual/
├── Form1.cs                 # Lógica principal
├── Form1.Designer.cs        # Interface visual
├── Form1.resx              # Recursos do formulário
├── Program.cs              # Ponto de entrada
├── PetVirtual.csproj       # Configuração do projeto
├── PetVirtual.sln          # Arquivo de solução
├── App.config              # Configurações da aplicação
├── pet_apenas.png          # Imagem do seu pet
└── Properties/             # Recursos e configurações
```

## Como usar

1. **Inicie a aplicação**: Seu pet aparecerá em estado triste
2. **Faça o check-in**: Clique no botão "Check-in Diário" 
3. **Pet feliz**: Após o check-in, o pet ficará feliz e a animação acelerará
4. **Próximo dia**: Na data seguinte, o pet voltará ao estado triste
5. **Repita**: Mantenha a rotina de check-in diário para manter seu pet feliz

## Personalização

### Substituir a imagem do pet
- Substitua o arquivo `pet_apenas.png` por sua própria imagem
- Recomendado: formato PNG, tamanho 150x150 pixels
- A imagem será redimensionada automaticamente

### Ajustar velocidades de animação
No arquivo `Form1.cs`, modifique as constantes:
```csharp
private const float SLOW_SPEED = 0.5f;   // Velocidade triste
private const float FAST_SPEED = 2.0f;   // Velocidade feliz
private const float ANIMATION_RANGE = 15f; // Amplitude do movimento
```

## Arquivos gerados

A aplicação cria automaticamente:
- `pet_data.txt`: Armazena estado do pet e data do último check-in

## Interface Visual

- **Fundo**: Azul claro
- **Fonte**: Arial para boa legibilidade  
- **Cores**: Verde para feliz, vermelho para triste
- **Animação**: 20 FPS para movimento suave

## Para Desenvolvedores

### Arquitetura
- Padrão Windows Forms tradicional
- Timer para controle de animação (50ms de intervalo)
- Persistência simples via arquivo de texto
- Detecção de mudança de data usando `DateTime.Today`

### Principais métodos
- `InitializePet()`: Configura imagem e animação
- `CheckDayChange()`: Verifica mudança de data
- `UpdateUI()`: Atualiza interface baseada no estado
- `AnimationTimer_Tick()`: Controla movimento do pet

## Licença

Este projeto foi desenvolvido para fins educacionais e de entretenimento.
