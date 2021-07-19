# desafio_dotnet_angular
Pequena API de teste utilizando os conhecimentos em CQRS DDD, SOLID dotNetCore Api e Angular Framework

# Versões
<ul>
  <li>
    .Net Core Versão 3.1
 </li>
   <li>
    EntityFrameworkCore 3.1.1
 </li>
    <li>
    flunt 1.0.4
 </li>
     <li>
    FluentMigrator 3.2.17
 </li>
     <li>
   MediatR 9.0.0
 </li>
    <li>
    Angular Versão 10.0.8
 </li>
</ul>
# Sobre
<ul>
  <li>
   Nesse projeto foi utilizado o padrão CQRS com auxilio do biblioteca MediatR, para criação e manutenção dos Handlers
 </li>
   <li>
    No Projeto de Infra, foi utilizado Entity Framework Core, junto do Flient Migrations para criação, mapeamento, e manutenção do banco de dados.
    O banco utilizado foi o SQL Server 
 </li>
    <li>
    Foi utlizado a biblioteca flunt para validação dos modelos que eram trazidos direto do front end, e também para devolver qualquer mensagem de erro durante a validação
 </li>
    <li>
   Para o front end foi utilizado o Angular versão 10 com bootstrap 
 </li>
</ul>
# Executar

<ul>
  <li>
   Antes de executar o Projeto é necessário a criação do banco através do SQL Server, crie um banco de dados com o Nome de Projur.
  </li>
  <li>
    É necessário atualizar a connectionString no appsettings para que o projeto funcione corretamente no computador.
  </li>
    <li>
    Após esses passos já é possivel executar o back-end 
  </li>
  <li>
  Navega com o CMD ou Terminal até a pasta do Aplicativo em angular e execute o comando "npm i" esse comando vai buscar as dependencias do projeto 
  </li>
    <li>
 Execute o front-end Angular com o comando "ng serve -o" dentro da pasta do projeto de front-end
  </li>  
  <li>
 Execute o BackEnd .Net Core com o comando "dotnet watch run" dentro da pasta do projeto da API
  </li>
</ul>
