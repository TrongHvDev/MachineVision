﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGB2Binary
{

    public partial class Form1 : Form
    {
        Bitmap hinhgoc;
        public Form1()
        {
            InitializeComponent();
            string filehinh = @"E:\Nam_3\ThiGiacMay\Images\Lenna.jpg"; // kí tự @ giúp C#.NET hiểu là chuỗi unicode, khong bao loi
            
            // Tạo một biến chứa hình Bitmap được load từ file hình trên.
            hinhgoc = new Bitmap(filehinh);

            // Hiển thị hình trong picBox_hinhgoc đã tạo
            picBox_AnhGoc.Image = hinhgoc;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public Bitmap ChuyenHinhRGBsangBinary(Bitmap hinhgoc, byte nguong)
        {
            // Khai báo hình Bitmap để load hình mưc xám
            Bitmap hinhnhiphan = new Bitmap(hinhgoc.Width, hinhgoc.Height);

            for (int x = 0; x < hinhgoc.Width; x++)
                for (int y = 0; y < hinhgoc.Height; y++)
                {
                    // Doc giá trị pixel tại điểm ảnh có giá trị (x,y)
                    Color pixel = hinhgoc.GetPixel(x, y);
                    // Mỗi pixel gồm 4 thông tin chứa 4 giá trị màu R, G ,B và giá trị màu trong suốt
                    byte R = pixel.R;
                    byte G = pixel.G;
                    byte B = pixel.B;
                    byte A = pixel.A;

                    //Tính giá trị mức xám cho điểm ảnh tại (x, y)
                    byte nhiphan = (byte)(R * 0.2126 + G * 0.7152 + B * 0.0722);
                    //nhiphan khai báo là byte, r,g,b là kiêu số thưc 
                    //nên cần phải ép kiểu về byte

                    //Phân loại pixel dựa vào giá trị ngưỡng
                    if (nhiphan < nguong)
                        nhiphan = 0;
                    else
                        nhiphan = 255;

                    //Set gía trị pixel đọc được vào các kênh màu
                    hinhnhiphan.SetPixel(x, y, Color.FromArgb(nhiphan, nhiphan, nhiphan));

                }
            return hinhnhiphan;
        }
        private void picBox_hinhgoc_Click(object sender, EventArgs e)
        {

        }

        private void ScrollBar_ValueChanged(object sender, EventArgs e)
        {
            //Do value của thanh cuộn là int nên cần phải ép kiểm byte
            byte nguong = (byte)ScrollBar.Value;

            //Cho hiển thị giá trị ngưỡng
            lb_Nguong.Text = nguong.ToString();

            //Hiển thị hinh nhi phân
            picBox_Binary.Image = ChuyenHinhRGBsangBinary(hinhgoc, nguong);
        }
    }
}
