namespace CasaPopular.Domain.Enuns
{
    public enum TipoPessoa
    {
        Pretendente,
        Conjuge,
        Dependente
    }

    public enum TipoCriterio
    {
        RendaTotal,
        IdadePretendente,
        NumeroDependente
    }

    public enum Status
    {
        CadastroValido,
        JaPossuiCasa,
        JaSelecionada,
        CadastroImcompleto
    }
}