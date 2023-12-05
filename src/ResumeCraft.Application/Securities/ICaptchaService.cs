namespace ResumeCraft.Application.Securities
{
    public interface ICaptchaService
    {
        Task<bool> IsCaptchaValid(string captcha);
    }
}
