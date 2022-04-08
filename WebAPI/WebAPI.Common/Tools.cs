
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


namespace WebAPIPractise.Common
{
    public class Tools
    {

        public static string CreateValidateString()
        {
            //準備一組供驗證碼展示的數據
            string chars = "abcdefghijklmnopqrstuvwxyz";
            Random r = new(DateTime.Now.Millisecond);
            string validateString = "";
            int length = 4;
            for (int i = 0; i < length; i++)
            {
                validateString += chars[r.Next(chars.Length)];
            }
            return validateString;
        }

        public static byte[] CreateValidateCodeBuffer(string validateCode)
        {
            //bmp->圖
            //1. 創建畫布,設置畫布的長寬
            using Bitmap bitmap = new(200, 60);

            //2. 創建畫筆,告訴畫筆在哪個畫布上面畫畫
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);//用白色覆蓋畫布,並清除畫布上所有的內容

            //設置字體的參數(設置字體名稱,大小,粗細已急斜體)
            Font font = new("微軟雅黑", 12, FontStyle.Bold | FontStyle.Italic);
            //通過graphics.MeasureString方法計算字符串的長度
            var size = graphics.MeasureString(validateCode, font);
            
            //像上取整:天花板函數;向下取整:地板函數
            using Bitmap bitmapText = new(Convert.ToInt32(Math.Ceiling(size.Width)), Convert.ToInt32(Math.Ceiling(size.Height)));
            //將文字寫入,生成圖片
            Graphics graphicsText = Graphics.FromImage(bitmapText);

            //將圖片縮放放到原畫布上

            //3. 配置畫圖參數
            //3.1設置顏色刷範圍參數
            RectangleF rf = new(0, 0, bitmap.Width, bitmap.Height);
            //3.2設置刷子的顏色(設置為漸變)
            LinearGradientBrush brush = new(rf, Color.Red, Color.DarkBlue, 1.2f, true);

            //4.將字符串繪製到場景中
            graphicsText.DrawString(validateCode, font, brush, 0, 0);

            graphics.DrawImage(bitmapText, 10, 10, 190, 50);
            //5.將圖片放到緩衝區
            //5.1創建一個用於保存圖片的緩衝器
            MemoryStream memoryStream = new ();
            bitmap.Save(memoryStream, ImageFormat.Jpeg);

            //6.這個時候圖片只京到緩衝區了,bitmap對象自然就沒有用了
            return memoryStream.ToArray();

        }
    }
}
