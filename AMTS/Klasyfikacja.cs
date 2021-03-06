﻿using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AMTS.Data
{
    public partial class Klasyfikacja: AbstractForm 
    {
        SqlConnection connection;
        AbstractForm mainForm;

        public Klasyfikacja(SqlConnection connection, AbstractForm MF)
        {
            mainForm = MF;
            InitializeComponent();
            this.connection = connection;
            DataSet dataSet = new DataSet();
            SqlDataAdapter dataAd = new SqlDataAdapter("SELECT * FROM KLASYFIKACJA ORDER BY Duze_punkty DESC", connection);
            SqlCommandBuilder command = new SqlCommandBuilder(dataAd);
            dataAd.Fill(dataSet, "KLASYFIKACJA");
            klasyfikacjaDataGridView.DataSource = dataSet.Tables["KLASYFIKACJA"];
            klasyfikacjaDataGridView.ReadOnly = true;
        }

        private void Klasyfikacja_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.changeOpenedWindow();
        }
    }
}
