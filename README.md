### **Comparação de Clientes HTTP em .NET**
**Objetivo**

Este projeto tem como objetivo comparar o desempenho de diferentes implementações de clientes HTTP disponíveis em .NET, incluindo HttpClient, RestSharp e Flurl. O foco é avaliar e contrastar essas bibliotecas em termos de eficiência, uso de memória e tempo de resposta em operações padrão de consumo de API.

**Tecnologias Utilizadas**

- .NET 8: Aplicação console.
- HttpClient: Cliente HTTP nativo do .NET.
- RestSharp: Biblioteca de terceiros popular para operações HTTP em .NET.
- Flurl: Biblioteca que oferece uma interface fluente para construir e chamar URLs HTTP.
- BenchmarkDotNet: Ferramenta para benchmarking de desempenho em .NET, utilizada para realizar testes comparativos de maneira precisa.

**Padrões e Práticas**

- Padrão Factory: Utilizado para a criação de instâncias de serviços HTTP de forma abstrata e desacoplada, facilitando a manutenção e expansão do código.
- Injeção de Dependência: Adotada para gerenciar as dependências das classes, permitindo um acoplamento flexível e facilitando testes unitários.
- Testes de Benchmark: Implementados usando o BenchmarkDotNet para garantir medições precisas e consistentes do desempenho de cada cliente HTTP.

**Estrutura do Projeto**

O projeto é estruturado da seguinte maneira:

- Services: Contém as implementações concretas dos clientes HTTP usando HttpClient, RestSharp e Flurl.
- Interfaces: Define as interfaces para abstrair as operações dos clientes HTTP.
- BenchmarkTests: Contém os testes de benchmark para comparar o desempenho das diferentes implementações.

**Executando o Projeto**

Para executar os benchmarks e comparar o desempenho dos clientes HTTP:

- Clone o repositório.
- Navegue até a pasta do projeto.
- Execute dotnet run -c Release para iniciar os testes de benchmark.

**Contribuições**

Contribuições são bem-vindas! Se você tiver sugestões ou melhorias, sinta-se à vontade para criar uma issue ou um pull request.
