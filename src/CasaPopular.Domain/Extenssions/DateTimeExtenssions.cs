using System;

namespace CasaPopular.Domain.Extenssions
{
    public static class DateTimeExtenssions
    {
        public static int Idade(this DateTime dataNascimento)
        {
            var idade = DateTime.Now.Year - dataNascimento.Year;

            if (DateTime.Now.AddYears(idade) > DateTime.Now)
                idade--;

            return idade;
        }
    }
}