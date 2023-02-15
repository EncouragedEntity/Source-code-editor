﻿using FastColoredTextBoxNS;
using SourceCodeEditor.Forms.Templates;

namespace SourceCodeEditor.Forms
{
    public partial class TemplatesForm : Form
    {
        public FastColoredTextBox TextField { get; set; }
        public TemplatesForm(FastColoredTextBox textField)
        {
            InitializeComponent();
            SetButtonsEvents();
            TextField = textField;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SetButtonsEvents()
        {
            foreach (var control in tableLayoutPanel1.Controls)
            {
                if(control is PictureBox)
                {
                    PictureBox picbox = (PictureBox)control;
                    picbox.Click += ButtonClick;
                }
            }
        }

        private int GetPictureBoxNumber(PictureBox button)
        {
            return int.Parse(button.Name.Last().ToString()) - 1;
        }

        public Label? GetLabelById(int id)
        {
            var label = tableLayoutPanel1.Controls.OfType<Label>().Where(value => value.Name == $"label{id+1}").FirstOrDefault();
            return label;
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            var button = (PictureBox)sender;
            int templateNum = GetPictureBoxNumber(button);

            if (button.Name.Contains("Play"))
            {
                TemplatePlay(templateNum);
                return;
            }
            if (button.Name.Contains("Edit"))
            {
                TemplateEdit(templateNum);
                return;
            }
            if (button.Name.Contains("Delete"))
            {
                TemplateDelete(templateNum);
                return;
            }
        }

        /// TODO Edit form, add form, play method

        private void TemplatePlay(int templateNumber)
        {
            if (!File.Exists($"Templates/Template{templateNumber}.txt"))
            {
                TemplateAdd(templateNumber);
            }
        }

        private void TemplateAdd(int templateNumber)
        {
            string FolderPath = "Templates";
            string TemplateName = $"Template{templateNumber+1}.txt";
            string FilePath = $"{FolderPath}/{TemplateName+1}";

            var template = new Template();
            template.Name = TemplateName;
            template.Number = templateNumber;


            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }

            var addTemplate = new TemplateAddForm(this, template, FilePath);

            addTemplate.ShowDialog();
        }

        private void TemplateEdit(int templateNumber)
        {

        }

        private void TemplateDelete(int templateNumber)
        {

        }

        private void TemplatesForm_Load(object sender, EventArgs e)
        {

        }
    }
}