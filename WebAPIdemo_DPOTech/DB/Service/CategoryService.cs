﻿using WebAPIdemo_DPOTech.DB.IService;
using WebAPIdemo_DPOTech.DB.DbWebContext;
using WebAPIdemo_DPOTech.DB.Models;


namespace WebAPIdemo_DPOTech.DB.Service;

public class CategoryService:ICategoryService
{
    private readonly DbWebContext.DbWebContext _dbContext;
    public CategoryService(DbWebContext.DbWebContext dbContext )
    {
        _dbContext=dbContext;
    }
    public List<Category> GetData()
    {
        try
        {
            return _dbContext.Categories.ToList();
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public string Add(T @object)
    {
        try
        {
            _dbContext.Categories.Add(@object);
            return "Sucessful";
        }
        catch (Exception e)
        {
            return "Erorr" + e;
        }
    }

    public string Edit(T @object)
    {
        try
        {
            _dbContext.Categories.Update(@object);
            return "Sucessful";
        }
        catch (Exception e)
        {

            return "Erorr" + e;
        }
    }

    public string Delete(T @object)
    {
        try
        {
            _dbContext.Categories.Remove(@object);
            return "Sucessful";
        }
        catch (Exception e)
        {
            return "Erorr"+ e;
        }
    }

    public string Save()
    {
        try
        {
            _dbContext.SaveChanges();
            return "Sucessful";
        }
        catch (Exception e)
        {
            return "Erorr" + e;
        }
    }
}