using System;
using System.Collections.Generic;
using System.DrawingCore;
using System.DrawingCore.Drawing2D;
using System.DrawingCore.Imaging;
using System.IO;
using System.Text;

namespace DotnetCore.Code.Code
{
    /// <summary>
    /// 生成验证码的类
    /// </summary>
    public class ValidateCode
    {
        /// <summary>
        /// 验证码的最大长度
        /// </summary>
        public int MaxLength => 10;

        /// <summary>
        /// 验证码的最小长度
        /// </summary>
        public int MinLength => 1;

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <param name="length">指定验证码的长度</param>
        /// <returns></returns>
        public string CreateValidateCode(int length)
        {
            int[] randMembers = new int[length];
            int[] validateNums = new int[length];
            string validateNumberStr = "";
            //生成起始序列值
            int seekSeek = unchecked((int)DateTime.Now.Ticks);
            Random seekRand = new Random(seekSeek);
            int beginSeek = seekRand.Next(0, int.MaxValue - length * 10000);
            int[] seeks = new int[length];
            for (int i = 0; i < length; i++)
            {
                beginSeek += 10000;
                seeks[i] = beginSeek;
            }
            //生成随机数字
            for (int i = 0; i < length; i++)
            {
                Random rand = new Random(seeks[i]);
                int pownum = 1 * (int)Math.Pow(10, length);
                randMembers[i] = rand.Next(pownum, int.MaxValue);
            }
            //抽取随机数字
            for (int i = 0; i < length; i++)
            {
                string numStr = randMembers[i].ToString();
                int numLength = numStr.Length;
                Random rand = new Random();
                int numPosition = rand.Next(0, numLength - 1);
                validateNums[i] = Int32.Parse(numStr.Substring(numPosition, 1));
            }
            //生成验证码
            for (int i = 0; i < length; i++)
            {
                validateNumberStr += validateNums[i].ToString();
            }
            return validateNumberStr;
        }

        /// <summary>
        /// 创建验证码的图片
        /// </summary>
        /// <param name="validateCode">验证码</param>
        public byte[] CreateValidateGraphic(string validateCode)
        {
            // 画布对象
            Bitmap image = null;
            Graphics g = null;
            try
            {
                // 生成随机生成器
                Random random = new Random();

                //颜色列表，用于验证码、噪线、噪点 
                Color[] color = { Color.Black, Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Brown, Color.Brown, Color.DarkBlue };

                //字体列表，用于验证码 
                string[] font = { "Times New Roman" };

                //创建画布
                image = new Bitmap((int)Math.Ceiling(validateCode.Length * 12.0), 36);
                g = Graphics.FromImage(image);

                // 清空图片背景色
                g.Clear(Color.Aqua);

                // 画图片的干扰线
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    Color clr = color[random.Next(color.Length)];
                    g.DrawLine(new Pen(clr), x1, y1, x2, y2);
                }

                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2F, true);

                //画验证码字符串 
                for (int i = 0; i < validateCode.Length; i++)
                {
                    string fnt = font[random.Next(font.Length)];
                    Font ft = new Font(fnt, 16);
                    Color clr = color[random.Next(color.Length)];
                    g.DrawString(validateCode[i].ToString(), ft, new SolidBrush(clr), (float)i * 18, (float)0);
                }

                //画图片的前景干扰点
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }

                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

                //保存图片数据
                MemoryStream stream = new MemoryStream();
                image.Save(stream, ImageFormat.Jpeg);

                //输出图片流
                return stream.ToArray();
            }
            finally
            {
                g?.Dispose();
                image?.Dispose();
            }
        }

        /// <summary>
        /// 得到验证码图片的长度
        /// </summary>
        /// <param name="validateNumLength">验证码的长度</param>
        /// <returns></returns>
        public static int GetImageWidth(int validateNumLength)
        {
            return (int)(validateNumLength * 12.0);
        }

        /// <summary>
        /// 得到验证码的高度
        /// </summary>
        /// <returns></returns>
        public static double GetImageHeight()
        {
            return 22.5;
        }
    }
}