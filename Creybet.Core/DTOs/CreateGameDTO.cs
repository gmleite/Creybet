namespace Creybet.Core.DTOs;


public partial class CreateGameDTO
{
    public string CreatedBy { get; set; }

    public CreateGameDTO()
    {
        if (CreatedBy == null)
        {
            CreatedBy = "";
        }
    }
}