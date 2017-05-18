namespace DotnetCore.Model.Transfer
{
    /// <summary>
    /// 登录model
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 帐号
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string ValidateCode { get; set; }
    }
}