namespace DotnetAPI.Models.Requests {

public class UpdateUserRequest {

        public string? FirstName {get; set;}

        public string? LastName {get; set;}

        public string? Email {get; set;}

        public string? Gender {get; set;}

        public bool Active {get; set;}
}

}