namespace Core.Application.Requests
{
    public class PageRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
//User işlemlerine bak..
//https://github.com/tuncayalt/Kodlama.io.Devs/blob/main/src/demoProjects/devs/Application/Features/ApplicationUsers/Commands/UpdateApplicationUser/UpdateApplicationUserCommandHandler.cs