using GoogleReCaptcha.V3.Interface;
using ResumeCraft.Application.Securities;

namespace ResumeCraft.Infrastructure.Securities
{
    public class CaptchaService : ICaptchaService
    {
        private readonly ICaptchaValidator _captchaValidator;

        public CaptchaService(ICaptchaValidator captchaValidator)
        {
            _captchaValidator = captchaValidator;
        }

        public async Task<bool> IsCaptchaValid(string captcha)
        {
            return await _captchaValidator.IsCaptchaPassedAsync(captcha);
        }
    }
}
