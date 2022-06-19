using Swashbuckle.AspNetCore.Annotations;

namespace GettingBetter.API.GettingBetter_System.Resources;

public class CoachResource
{
    [SwaggerSchema("Coach Identifier")]
    public int Id { get; set; }
    [SwaggerSchema("Coach FirstName")]
    public string FirstName { get; set; }
    [SwaggerSchema("Coach LastName")]
    public string LastName { get; set; }
    [SwaggerSchema("Coach SelectedGame")]
    public string SelectedGame { get; set; }
    [SwaggerSchema("Coach NickName")]
    public string NickName { get; set; }
    [SwaggerSchema("Coach Email")]
    public string Email { get; set; }
    [SwaggerSchema("Coach Password")]
    public string Password { get; set; }
    [SwaggerSchema("Coach UserImage")]
    public string UserImage { get; set; }
    [SwaggerSchema("Coach Bibliography")] 
    public string Bibliography { get; set; }
}