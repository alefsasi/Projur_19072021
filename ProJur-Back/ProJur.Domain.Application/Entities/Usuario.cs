using System;
using ProJur.Domain.Application.Enums;
using ProJur.Domain.Application.Base;

namespace ProJur.Domain.Application.Entities
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public EscolaridadeEnum Escolaridade { get; set; }
    }
}