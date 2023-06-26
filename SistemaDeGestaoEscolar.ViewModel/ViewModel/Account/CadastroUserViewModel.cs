namespace SistemaDeGestaoEscolar.ViewModel
{
    public class CadastroUserViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Perfil { get; set; }
        public string Senha { get; set; }
        public string SenhaConfirmacao { get; set; }
        public bool Saving { get; set; }
    }
}