using Newtonsoft.Json;

namespace Application.Dto.Response.Public;

public class ApiBaseResult
{
    public bool Error { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public List<string?> Message { get; set; }

    public ApiBaseResult(bool error, string? message = null)
        : this()
    {
        Error = error;
        Message.Add(message ?? "OK");
    }

    public ApiBaseResult(List<string> errors)
       : this()
    {
        Message.AddRange(errors);
    }

    public ApiBaseResult()
    {
        Message = new List<string>();
    }


    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
