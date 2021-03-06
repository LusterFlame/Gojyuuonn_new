﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Gojyuonn_new
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			// when loaded, only selectPage should shows up, others should hide
			selectPage.Parent = this;
			selectPage.Location = new Point((this.ClientSize.Width - selectPage.Width) / 2, (this.ClientSize.Height - selectPage.Height) / 2);

			hiragana.Parent = this;
			hiragana.Location = new Point((this.ClientSize.Width - hiragana.Width) / 2, (this.ClientSize.Height - hiragana.Height) / 2);
			hiragana.Hide();

			katakana.Parent = this;
			katakana.Location = new Point((this.ClientSize.Width - katakana.Width) / 2, (this.ClientSize.Height - katakana.Height) / 2);
			katakana.Hide();

			kanjiyomi.Parent = this;
			kanjiyomi.Location = new Point((this.ClientSize.Width - kanjiyomi.Width) / 2, (this.ClientSize.Height - kanjiyomi.Height) / 2);
			kanjiyomi.Hide();

			// button_PrevPage should shows up when ever current page is not selectPage
			button_PrevPage.Hide();

			// set "SelectPage"'s event handlers
			selectPage.hira_clicked += (s, e) =>
			{
				selectPage.Hide();
				hiragana.Show();
				button_PrevPage.Show();
			};
			selectPage.kata_clicked += (s, e) =>
			{
				selectPage.Hide();
				katakana.Show();
				button_PrevPage.Show();
			};
			selectPage.kanji_clicked += (s, e) =>
			{
				selectPage.Hide();
				kanjiyomi.Show();
				button_PrevPage.Show();
			};

			// set anchor to none to let it always on center
			selectPage.Anchor = AnchorStyles.None;
			hiragana.Anchor = AnchorStyles.None;
			katakana.Anchor = AnchorStyles.None;
			kanjiyomi.Anchor = AnchorStyles.None;
		}

		SelectPage selectPage = new SelectPage();
		QusControl hiragana = new QusControl(@"Resources\hirakana.json");
		QusControl katakana = new QusControl(@"Resources\katagana.json");
		QusControl kanjiyomi = new QusControl(@"Resources\kanjiyomi.json");

		private void button_PrevPage_Click(object sender, EventArgs e)
		{
			hiragana.Hide();
			katakana.Hide();
			kanjiyomi.Hide();
			button_PrevPage.Hide();

			selectPage.Show();
		}

		private void 字體ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(fontDialog1.ShowDialog() == DialogResult.OK)
			{
				var font = fontDialog1.Font;
				hiragana.font = font;
				katakana.font = font;
				kanjiyomi.font = font;
			}
		}
	}
}
