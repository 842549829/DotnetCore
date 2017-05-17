namespace DotnetCore.Code.Code
{
    /// <summary>
    /// 自定义异常
    /// </summary>
    public class CustomException : System.Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomException"/> class.
        /// 构造函数
        /// </summary>
        public CustomException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomException"/> class.
        /// 构造函数
        /// </summary>
        /// <param name="message">错误消息</param>
        public CustomException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomException"/> class.
        /// 构造函数
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="inner">异常信息</param>
        public CustomException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}