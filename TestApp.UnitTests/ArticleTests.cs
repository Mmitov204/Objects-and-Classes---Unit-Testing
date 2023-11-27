using NUnit.Framework;

using System;
using System.Collections.Generic;
using TestApp.Store;

namespace TestApp.UnitTests;

public class ArticleTests
{
    private Article _article;
    [SetUp]
        public void SetUp()
    {
        this ._article = new Article(); 
    }

    [Test]
    public void Test_AddArticles_ReturnsArticleWithCorrectData()
    {
        // Arrange
        string[] articleData =
        {
            "Article Content Author",
            "Article2 Content2 Author2",
            "Article3 Content3 Author3"
        };
        // Act
        Article result = this._article.AddArticles(articleData);
        // Assert
        Assert.That(result.ArticleList, Has.Count.EqualTo(3));
        Assert.That(result.ArticleList[0].Title, Is.EqualTo("Article"));
        Assert.That(result.ArticleList[1].Content, Is.EqualTo("Content2"));
        Assert.That(result.ArticleList[2].Author, Is.EqualTo("Author3"));
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByTitle()
    {
        // Arrange
        var inputArticle = new Article
        {
            ArticleList = new List<Article>
        {
            new Article
            {
                Author = "Teodor",
                Content = "ABS",
                Title = "New",
            },
            new Article
            {
                Author = "Bob",
                Content = "ADR",
                Title = "C+"
            }
        }
        };

        string expected = $"C+ - ADR: Bob{Environment.NewLine}New - ABS: Teodor";

        // Act
        string actual = this._article.GetArticleList(inputArticle, "title");

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetArticleList_ReturnsEmptyString_WhenInvalidPrintCriteria()
    {
        // Arrange
        var inputArticle = new Article
        {
            ArticleList = new List<Article>
        {
            new Article
            {
                Author = "Teodor",
                Content = "ABS",
                Title = "New",
            },
            new Article
            {
                Author = "Bob",
                Content = "ADR",
                Title = "C+"
            }
        }
        };

        

        // Act
        string actual = this._article.GetArticleList(inputArticle, "SSD");

        // Assert
        Assert.AreEqual(string.Empty, actual);
    }
}
