﻿using System;
using System.Collections.Generic;
using System.Linq;
using Trinity.Application.Interfaces;
using Trinity.Application.Model;
using Trinity.Application.Validators;
using Trinity.Domain.Model;
using Trinity.Domain.Repositories;

namespace Trinity.Application.Services
{
    public class MusicAppService : AppService<Music>, IMusicAppService
    {
        readonly MusicValidator Validator;

        public MusicAppService(
            IMusicRepository repository,
            MusicValidator validator
        ) : base(repository)
        {
            Validator = validator;
        }

        public MusicDisplayingModel Create(MusicInsertingModel model)
        {
            Validator.Validate(model);
            Music entity = model;
            Repository.Create(entity);
            Repository.SaveDbChanges();
            if (Exists(entity))
            {
                return entity;
            }
            throw new InternalServerException("An error ocurred while saving the model");
        }

        public void Delete(long id)
        {
            if (!Exists(id))
            {
                throw new EntityNotFoundException("Entity not found");
            }
            Repository.Delete(id);
            Repository.SaveDbChanges();
            if (Exists(id))
            {
                throw new InternalServerException("An error ocurred while deleting the register");
            }
        }

        public List<MusicDisplayingModel> GetAll()
        {
            return Repository.List().ToList()
                .Select(m => (MusicDisplayingModel)m).ToList();
        }

        public MusicDisplayingModel Get(long id)
        {
            Music entity = Repository.Find(id);
            if (!Exists(entity))
            {
                throw new EntityNotFoundException("Entity not found");
            }
            return entity;
        }

        public MusicDisplayingModel Update(MusicUpdatingModel model)
        {
            Music entity = Repository.Find(model.Id);
            if (!Exists(entity))
            {
                throw new EntityNotFoundException("Entity not found");
            }
            Validator.Validate(model);
            Repository.Update(entity.FromValue(model));
            Repository.SaveDbChanges();
            return entity;
        }
    }
}