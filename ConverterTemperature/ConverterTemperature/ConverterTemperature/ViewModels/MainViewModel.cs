namespace ConverterTemperature.ViewModels
{

    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using System.ComponentModel;
    using System;

    //The class INotifyPropertyChanged is implemented 
    //for the "view" to see the changes

    public class MainViewModel: INotifyPropertyChanged
    {
        #region Events
        //evento implementado en la interfaz    
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region properties

        public string gradeOneEntry
        {
            get
            {
                return _gradeOne;
            }

            set
            {
                if (value != _gradeOne)
                {
                    _gradeOne = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(gradeOneEntry)));
                }
            }
        }

        public string gradeTwoEntry
        {
            get
            {
                return _gradeTwo;
            }

            set
            {
                if (value != _gradeTwo)
                {
                    _gradeTwo = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(gradeTwoEntry)));
                }
            }
        }

        public string titleLabel
        {
            get
            {
                return _tittle;
            }

            set
            {
                if (value != _tittle)
                {
                    _tittle = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(titleLabel)));
                }
            }
        }

        public string textOneLabel
        {
            get
            {
                return _textOne;
            }

            set
            {
                if (value != _textOne)
                {
                    _textOne = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(textOneLabel)));
                }
            }
        }

        public string textTwoLabel
        {
            get
            {
                return _textTwo;
            }

            set
            {
                if (value != _textTwo)
                {
                    _textTwo = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(textTwoLabel)));
                }
            }
        }
        #endregion

        #region Atributtes
        string _tittle;
        string _gradeOne;
        string _gradeTwo;
        string _textOne;
        string _textTwo;

        #endregion

        #region constructors
        public MainViewModel()
        {
            titleLabel = "convert the celsius to fahrenheit";
            textOneLabel = "Grades Celsius";
          //  gradeOneEntry = "Enter Grades Celsius";
            textTwoLabel = "Grades Fahrenheit";
           // gradeTwoEntry = "Enter Grades Fahrenheit";
        }
        #endregion

        #region Commands

        //para que reconozaca el Icommand se importa using windows input
        //y se instala nuget de mvvm light libs

        public ICommand convertCommand
        {
            //solo lectura
            get { return new RelayCommand(convert); }
        }

        

        //async es un modificador asincrono
        async void convert()
        {
            if (string.IsNullOrEmpty(gradeOneEntry))
            {
                //Metodo asincrono
                await App.Current.MainPage.DisplayAlert("Error", "¡You must enter a value in " + textOneLabel +" !", "Accept");

                return;
            }

            double grade = 0;

            if (!double.TryParse(gradeOneEntry, out grade))

            {
                await App.Current.MainPage.DisplayAlert("Error", "¡You must enter a value numeric in " + textOneLabel + " !", "Accept");
                gradeOneEntry = null;
                return;
            }

            double gradeConverted =0;
            //It verifies what type of degrees is
            if (textOneLabel == "Grades Celsius")
            {
                 gradeConverted = (grade * 1.8) + 32;
            }
            else
            {
                gradeConverted = ((grade - 32) * 0.555555556);
            }

            gradeTwoEntry = gradeConverted.ToString();
        }

        public ICommand invertCommand
        {
            //solo lectura
            get { return new RelayCommand(invert); }
        }

         void invert()
        {
            gradeOneEntry =null;
            gradeTwoEntry = null;
            if (textOneLabel == "Grades Celsius")
            {
                titleLabel = "convert the fahrenheit to Celsius";
                textOneLabel = "Grades Fahrenheit";
                //gradeOneEntry = "Enter Grades Fahrenheit";
                textTwoLabel = "Grades Celsius";
                // gradeTwoEntry = "Enter Grades Celsius";
                //                   Placeholder="Enter centigrade grades"
                //PlaceholderColor = "Black"
            }
            else
            {
                titleLabel = "convert the celsius to fahrenheit";
                textOneLabel = "Grades Celsius";
                //  gradeOneEntry = "Enter Grades Celsius";
                textTwoLabel = "Grades Fahrenheit";
                //gradeTwoEntry = "Enter Grades Fahrenheit";

            }
        }

        #endregion
    }
}
