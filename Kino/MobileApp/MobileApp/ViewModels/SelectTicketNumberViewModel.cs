using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.ViewModels
{
    public class SelectTicketNumberViewModel : BaseViewModel
    {
        private Models.Movie _movie;

        private Kino.Model.Cinema _cinema;

        private Models.Screening _screening;

        private int _ticketNumber = 1;//min value

        public SelectTicketNumberViewModel(Models.Movie movie, Kino.Model.Cinema cinema, Models.Screening screening)
        {
            Movie = movie;
            Cinema = cinema;
            Screening = screening;
        }

        public Models.Movie Movie
        {
            get
            {
                return _movie;
            }

            set
            {
                SetProperty(ref _movie, value);
            }
        }

        public Kino.Model.Cinema Cinema
        {
            get
            {
                return _cinema;
            }

            set
            {
                SetProperty(ref _cinema, value);
            }
        }

        public Models.Screening Screening
        {
            get
            {
                return _screening;
            }

            set
            {
                SetProperty(ref _screening, value);
            }
        }

        public int TicketNumber
        {
            get
            {
                return _ticketNumber;
            }

            set
            {
                SetProperty(ref _ticketNumber, value);
            }
        }
    }
}
