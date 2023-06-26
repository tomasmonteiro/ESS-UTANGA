namespace SistemaDeGestaoEscolar.Common
{
    public enum DireitoDeAcessoEnum : int
    {
        AcessarCadastroPerfilUsuario = 1,
        IncluirPerfilUsuario,
        AlterarPerfilUsuario,
        ExcluirPerfilUsuario,
        IncluirAlterarPerfilUsuario,

        AcessarCadastroUsuario,
        IncluirAlterarCadastroUsuario,
        ExcluirCadastroUsuario,

        AcessarCadastroAluno,
        IncluirAlterarCadastroAluno,
        ExcluirCadastroAluno,

        AcessarCadastroProfessor,
        IncluirAlterarCadastroProfessor,
        ExcluirCadastroProfessor,

        AcessarCadastroTurma,
        IncluirAlterarCadastroTurma,
        ExcluirCadastroTurma,

        AcessarCadastroDisciplina,
        IncluirAlterarCadastroDisciplina,
        ExcluirCadastroDisciplina,

         AcessarCadastroCurso,
        IncluirAlterarCadastroCurso,
        ExcluirCadastroCurso,

        AcessarCadastroMatricula,
        IncluirAlterarCadastroMatricula,
        ExcluirCadastroMatricula
    }
}