using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CostaContest.Forms
{
    public class EditorBase : Form
    {
        protected ShowingMode Mode { get; private set; }
        public EditorBase()
        {
            this.Load += new EventHandler(EditorBase_Load);
            Mode = ShowingMode.Creating;
        }

        public EditorBase(ShowingMode mode) : this()
        {
            SetMode(mode);
        }

        private void EditorBase_Load(object sender, EventArgs e)
        {
            try
            {
                SetData();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        protected void SetMode(ShowingMode mode)
        {
            Mode = mode;
            if (Mode == ShowingMode.Showing)
            {
                LockEditing();
            }
        }

        protected virtual void LockEditing()
        {
        }

        /// <summary>
        /// Проверяет верно ли установлены данные и в случае ошибки показывает ее
        /// </summary>
        /// <returns></returns>
        protected bool CheckModel()
        {
            try
            {
                return UpdateData();
            }
            catch (Exception e)
            {
                ShowError(e.Message);
                return false;
            }
        }

        protected virtual void SetData()
        {
        }

        /// <summary>
        /// Обновляет данные модели. Если обновление прошло успешно, возвращает true
        /// </summary>
        /// <returns></returns>
        protected virtual bool UpdateData()
        {
            return false;
        }

        protected void ShowError(string text, string title = "Ошибка")
        {
            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
