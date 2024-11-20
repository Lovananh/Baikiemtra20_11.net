﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baikiemtra2011
{
    public partial class Donhang : Form
    {
        public Donhang()
        {
            InitializeComponent();
        }
        Connect db = new Connect();
        public void getData()
        {
            string query = "select * from Donhang";
            DataSet ds = db.Laydulieu(query);
            dataGridViewDonhang.DataSource = ds.Tables[0];
        }

        private void Lammoi()
        {
            txtTenkh.Clear();
            txtSanpham.Clear();
            txtSoluong.Clear();
            dateTimePickerNgaymua.Value = DateTime.Now; 
            btnThem.Enabled = true; 
            btnSua.Enabled = false; 
            btnXoa.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            string query = string.Format(
                "insert into Donhang (khachhangid, sanphamid, soluong, ngaymua)  VALUES('{0}', N'{1}', {2}, N'{3})",
                txtTenkh.Text,
                txtSanpham.Text,
                txtSoluong.Text,
                dateTimePickerNgaymua.Value.ToString("yyyy-MM-dd")
            );
            if (db.ThucThi(query) == true)
            {
                MessageBox.Show("Thêm mới thành công!");

                getData();
                Lammoi();
            }
            else
            {
                MessageBox.Show("Thêm mới thất bại!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string query = string.Format(
                "UPDATE Donhang SET khachhangid = '{0}', sanphamid = '{1}', soluong = {2}, ngaymua = '{3}' WHERE id = {4}",
                txtTenkh.Text,
                txtSanpham.Text,
                txtSoluong.Text,
                dateTimePickerNgaymua.Value.ToString("yyyy-MM-dd") 
            );

            if (db.ThucThi(query))
            {
                MessageBox.Show("Sửa đơn hàng thành công!");

                getData();
                Lammoi();
            }
            else
            {
                MessageBox.Show("Sửa đơn hàng thất bại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string query = string.Format("DELETE FROM Donhang WHERE id = {0}", txtId.Text); // Truy vấn xóa đơn hàng

            if (db.ThucThi(query))
            {
                MessageBox.Show("Xóa đơn hàng thành công!");
                getData(); // Cập nhật lại dữ liệu trên DataGridView
                    Lammoi(); // Reset form sau khi xóa
            }
            else
            {
                MessageBox.Show("Xóa đơn hàng thất bại!");
            }
        }

        private void dataGridViewDonhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewDonhang.Rows[e.RowIndex];
                txtId.Text = row.Cells["id"].Value.ToString(); // Lấy ID của đơn hàng
                txtTenkh.Text = row.Cells["khachhangid"].Value.ToString();
                txtSanpham.Text = row.Cells["sanphamid"].Value.ToString();
                txtSoluong.Text = row.Cells["soluong"].Value.ToString();
                dateTimePickerNgaymua.Value = Convert.ToDateTime(row.Cells["ngaymua"].Value); // Hiển thị ngày mua

                btnThem.Enabled = false; // Vô hiệu hóa nút Thêm khi đang sửa hoặc xóa
                btnSua.Enabled = true; // Kích hoạt nút Sửa
                btnXoa.Enabled = true; // Kích hoạt nút Xóa
            }

        }

        private void Donhang_Load(object sender, EventArgs e)
        {
            getData();
        }
    }
}