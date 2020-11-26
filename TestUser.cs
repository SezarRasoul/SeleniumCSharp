namespace EvityJuno
{
    internal class TestUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string WrongEmail { get; set; }
        public string WrongPassword { get; set; }
        public string Title { get; internal set; }
        public string FirstName { get; internal set; }
        public string SurName { get; internal set; }
        public object Country { get; internal set; }
    }
}