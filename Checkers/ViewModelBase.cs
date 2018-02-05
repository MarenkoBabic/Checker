namespace Checkers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Caliburn.Micro;

    public class ViewModelBase : IDataErrorInfo, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged( string propertyName )
        {
            if( PropertyChanged != null )
            {
                PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
            }
        }

        public string this[string columnName]
        {
            get
            {
                return OnValidate( columnName );
            }
        }

        public string Error
        {
            get
            {
                return error;
            }
        }

        protected virtual string OnValidate( string propertyName )
        {
            if( string.IsNullOrEmpty( propertyName ) )
            {
                throw new ArgumentException( "Invalid property name", propertyName );
            }
            string error = string.Empty;
            object value = this.GetType().GetProperty( propertyName ).GetValue( this, null );

            var results = new List<ValidationResult>( 1 );

            var context = new ValidationContext( this, null, null ) { MemberName = propertyName };

            bool result = Validator.TryValidateProperty( value, new ValidationContext( this, null, null ) {
                MemberName = propertyName
            }, results );

            if( !result )
            {
                ValidationResult validationResult = results.First();
                error = validationResult.ErrorMessage;
            }

            this.error = error;

            OnPropertyChanged( "IsValid" );

            return error;
        }

        private string error;
    }

    //public abstract class PropertyValidateModel : IDataErrorInfo
    //{
    //    public string this[string columnName]
    //    {
    //        get
    //        {
    //            return OnValidate( columnName );
    //        }
    //    }

    //    public string Error
    //    {
    //        get
    //        {
    //            return error;
    //        }
    //    }

    //    protected virtual string OnValidate( string propertyName )
    //    {
    //        if( string.IsNullOrEmpty( propertyName ) )
    //        {
    //            throw new ArgumentException( "Invalid property name", propertyName );
    //        }
    //        string error = string.Empty;
    //        object value = this.GetType().GetProperty( propertyName ).GetValue( this, null );

    //        var results = new List<ValidationResult>( 1 );

    //        var context = new ValidationContext( this, null, null ) { MemberName = propertyName };

    //        bool result = Validator.TryValidateProperty( value, new ValidationContext( this, null, null ) {
    //            MemberName = propertyName
    //        }, results );

    //        if( !result )
    //        {
    //            ValidationResult validationResult = results.First();
    //            error = validationResult.ErrorMessage;
    //        }

    //        this.error = error;

    //        return error;
    //    }

    //    private string error;
    //}
}
