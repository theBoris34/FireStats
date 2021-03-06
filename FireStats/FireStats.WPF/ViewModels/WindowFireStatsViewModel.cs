﻿using System.Windows.Controls;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Windows;
using FireStats.WPF.Infrastructure.Commands;
using FireStats.WPF.ViewModels.Base;
using FireStats.WPF.Pages;
using FireStats.WPF.Models;
using System.Windows.Markup;
using FireStats.WPF.Services.Interfaces;
using System.ComponentModel;

namespace FireStats.WPF.ViewModels
{

    [MarkupExtensionReturnType(typeof(WindowFireStatsViewModel))]
    internal class WindowFireStatsViewModel : ViewModel, INotifyPropertyChanged
    {

        private IEnumerable<DataPoint> _TestDataPoints;
        public IEnumerable<DataPoint> TestDataPoints 
        { 
            get => _TestDataPoints; 
            set => Set(ref _TestDataPoints, value);
        }

        private readonly IAsyncDataService _AsyncData;

        public ShowFirePageViewModel ShowFirePage { get; }
        public WebServerViewModel WebServerPage { get; }


        private Page _CurrentPage;
        /// <summary>
        /// Текущая страница.
        /// </summary>
        public Page CurrentPage
        {
            get { return _CurrentPage; }
            set
            {
                Set(ref _CurrentPage, value);
            }
        }

        /// <summary>
        /// Текущий пользователь
        /// </summary>
        private string _CurrentUser = "Пользователь";
        public string CurrentUser 
        { 
            get { return _CurrentUser; }
            set
            {
                Set(ref _CurrentUser, value);
            }
        }

        #region Команды

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private void OnCloseApplicationCommandExecuted(object p)
        {
            if (MessageBox.Show("Закрыть приложение?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question).ToString() == "Yes")
                //(RootObject as Window)?.Close();
                Application.Current.Shutdown();
        }
        private bool CanCloseApplicationCommandExecute(object p) => true;

        #endregion


        #region EnterFirePageShowCommand
        public ICommand EnterFirePageShowCommand { get; }

        private void OnEnterFirePageShowCommandExecuted(object p)
        {
            CurrentPage = new EnterFirePage();
        }
        private bool CanEnterFirePageShowCommandExecute(object p) => true;
        #endregion


        #region ShowFirePageShowCommand

        public ICommand ShowFirePageShowCommand { get; }

        private void OnShowFirePageShowCommandExecuted(object p)
        {
            CurrentPage = new ShowFirePage();
        }
        private bool CanShowFirePageShowCommandExecute(object p) => true;
        #endregion

        #region ShowEmergancyPageShowCommand

        public ICommand ShowEmergancyPageShowCommand { get; }

        private void OnShowEmergancyPageShowCommandExecuted(object p)
        {
            CurrentPage = new ShowEmergancyPage();
        }
        private bool CanShowEmergancyPageShowCommandExecute(object p) => true;
        #endregion

        #region EnterEmergancyPageShowCommand

        public ICommand EnterEmergancyPageShowCommand { get; }

        private void OnEnterEmergancyPageShowCommandExecuted(object p)
        {
            CurrentPage = new EnterEmergancyPage();
        }
        private bool CanEnterEmergancyPageShowCommandExecute(object p) => true;
        #endregion
        //ChangeUser


        #region UserListPageShowCommand

        public ICommand UserListPageShowCommand { get; }

        private void OnUserListPageShowCommandExecuted(object p)
        {
            
            CurrentPage = new UserListPage();
        }
        private bool CanUserListPageShowCommandExecute(object p) => true;
        #endregion


        #region ShowPlotPageShowCommand

        public ICommand ShowPlotPageShowCommand { get; }

        private void OnShowPlotPageShowCommandExecuted(object p)
        {
            CurrentPage = new ShowPlotPage();
        }
        private bool CanShowPlotPageShowCommandExecute(object p) => true;
        #endregion

        #region ShowEmployeeListPageCommand

        public ICommand ShowEmployeeListPageCommand { get; }

        private void OnShowEmployeeListPageCommandExecuted(object p)
        {
            CurrentPage = new EmployeeListPage();
        }
        private bool CanShowEmployeeListPageCommandExecute(object p) => true;
        #endregion


        #region ChangeUserCommand
        /// <summary>
        /// Перезагрузка приложения.
        /// </summary>
        public ICommand ChangeUserCommand { get; }

      
        private void OnChangeUserCommandExecuted(object p)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
        private bool CanChangeUserCommandExecute(object p) => true;
        #endregion



        #region WebServerPageCommand
        /// <summary>
        /// Перезагрузка приложения.
        /// </summary>
        public ICommand WebServerPageCommand { get; }


        private void OnWebServerPageCommandExecuted(object p)
        {
            CurrentPage = new WebServerPage();
        }
        private bool CanWebServerPageCommandExecute(object p) => true;
        #endregion

        #endregion

        public WindowFireStatsViewModel(/*ShowFirePageViewModel FirePage,*/ IAsyncDataService AsyncData, WebServerViewModel WebServer)
        {
            CurrentPage = _CurrentPage;
            _AsyncData = AsyncData;
            //ShowFirePage = FirePage;
            this.WebServerPage = WebServer;
            //FirePage.MainModel = this;

            #region Команды

            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            EnterFirePageShowCommand = new LambdaCommand(OnEnterFirePageShowCommandExecuted, CanEnterFirePageShowCommandExecute);
            ShowFirePageShowCommand = new LambdaCommand(OnShowFirePageShowCommandExecuted, CanShowFirePageShowCommandExecute);
            ShowEmergancyPageShowCommand = new LambdaCommand(OnShowEmergancyPageShowCommandExecuted, CanShowEmergancyPageShowCommandExecute);
            EnterEmergancyPageShowCommand = new LambdaCommand(OnEnterEmergancyPageShowCommandExecuted, CanEnterEmergancyPageShowCommandExecute);
            UserListPageShowCommand = new LambdaCommand(OnUserListPageShowCommandExecuted, CanUserListPageShowCommandExecute);
            ChangeUserCommand = new LambdaCommand(OnChangeUserCommandExecuted, CanChangeUserCommandExecute);
            ShowPlotPageShowCommand = new LambdaCommand(OnShowPlotPageShowCommandExecuted, CanShowPlotPageShowCommandExecute);
            ShowEmployeeListPageCommand = new LambdaCommand(OnShowEmployeeListPageCommandExecuted,CanShowEmployeeListPageCommandExecute);
            WebServerPageCommand = new LambdaCommand(OnWebServerPageCommandExecuted, CanWebServerPageCommandExecute);
            #endregion

        }
        

    }
}
