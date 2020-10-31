﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Huboh.Domain.Services;
using Huboh.EntityFramework.Models;
using Huboh.FolderWatcher.Activities;
using Huboh.FolderWatcher.Activities.Mp3MetadataParser;
using Huboh.FolderWatcher.Interfaces;

namespace Huboh.FolderWatcher.Main
{
    public class Handler : IHandler
    {
        private UnitOfWork _unitOfWork;
        private MetadataParser _metadataParser;
        private string _path;


        private List<string> deletedFilesToProcess = new List<string>();
        private List<string> createdFilesToProcess = new List<string>();

        public Handler(UnitOfWork unitOfWork, MetadataParser metadataParser , string path)
        {
            this._unitOfWork = unitOfWork;
            this._metadataParser = metadataParser;
            this._path = path;
        }

        public void FileChangedHandler(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Deleted)
            {
                //int affectedRecordId = this._unitOfWork.SongRepository.GetAll().First(_song => _song.musicCompletePath == e.FullPath).id;
                //this._unitOfWork.SongRepository.Delete(affectedRecordId);
            }
            else if(e.ChangeType == WatcherChangeTypes.Created)
            {
                createdFilesToProcess.Add(e.FullPath);
                Console.WriteLine(createdFilesToProcess.Count.ToString());

                //song newSongToDB = this._metadataParser.GetSongObjectAsync(e.FullPath, _path).Result;
                //this._unitOfWork.SongRepository.Insert(newSongToDB);
            }
            //this._unitOfWork.Save();
        }

        public void FileRenamedHandler(object sender, RenamedEventArgs e)
        {
            //TODO Encapsulate inside a try/catch
            //Gets the ID of the renamed file to use in the Update() function
            int affectedRecordId = this._unitOfWork.SongRepository.GetAll().First(_song => _song.musicCompletePath == e.OldFullPath).id; 
            //Gets the object that corresponds to the id
            song affectedRecord = this._unitOfWork.SongRepository.GetByID(affectedRecordId);

            //Updates the path and the file name
            affectedRecord.musicCompletePath = e.FullPath;
            affectedRecord.musicFilename = e.Name;

            //Creates a new object, for the sake of comprehension
            song newDBRecord = affectedRecord;

            this._unitOfWork.SongRepository.Update(affectedRecordId, newDBRecord);
            this._unitOfWork.Save();
        }


    }
}
