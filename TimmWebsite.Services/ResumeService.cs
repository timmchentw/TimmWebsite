using System;
using System.Collections.Generic;
using System.Linq;
using TimmWebsite.Shared.Enums;

namespace TimmWebsite.Services
{
    public class ResumeService : IResumeService
    {
        public List<ResumePortfolioDto> GetPortfolio()
        {
            var dtos = new List<ResumePortfolioDto>()
            { 
                new ResumePortfolioDto()
                {
                    Title = "使用Dapper搭配T4 Template建立Unit of Work資料層架構",
                    Text = "自動化資料庫欄位與初始值映射，並使用SQL搭配Dapper建立客製化ORM架構，並引入Unit of work增加寫入失敗之彈性，達到Database First與專案維護性之平衡",
                    ImgUrl = "/images/unit of work.png",
                    Tags = new List<PortfolioTag>() { PortfolioTag.Backend }
                },
                new ResumePortfolioDto()
                {
                    Title = "應用Hangfire優化自動化排程管理",
                    Text = "於.Net Core應用Hangfire OWIN架構，除安裝擴充套件增加功能，也進一步客製化排程狀態以方便管理，並導入AOP簡化重複流程、且允許各排程間保留獨立執行環境，達到彈性化排程控管",
                    ImgUrl = "/images/hangfire.png",
                    Tags = new List<PortfolioTag>() { PortfolioTag.DevOps, PortfolioTag.Backend }
                },
                new ResumePortfolioDto()
                {
                    Title = "應用Azure Pipeline實現私有伺服器CI/CD自動化佈署",
                    Text = "整合版控與程式佈署，並搭配Unit test實現私有伺服器之自動化測試、佈署、簽核與退版等，有Windows及Linux之佈署經驗",
                    ImgUrl = "/images/cicd.png",
                    Tags = new List<PortfolioTag>() { PortfolioTag.DevOps }
                },
                new ResumePortfolioDto()
                {
                    Title = "租賃Linux虛擬主機、註冊網域與自動化佈署",
                    Text = "租賃Ubuntu VPS運作.net Core網頁、程式與排程，搭配自行註冊的網域與SSL憑證供使用，並使用CI/CD Pipeline進行自動化佈署",
                    ImgUrl = "/images/ubuntu.png",
                    Tags = new List<PortfolioTag>() { PortfolioTag.DevOps }
                },
                new ResumePortfolioDto()
                {
                    Title = "應用React.js前端架構於.Net Framework",
                    Text = "使用Functional Component與Hook，搭配Reducer與Global State Manager，組成一套彈性且嚴謹的前端架構，並利用Webpack與Babel進行打包與轉譯",
                    ImgUrl = "/images/react.png",
                    Tags = new List<PortfolioTag>() { PortfolioTag.Frontend }
                },
                new ResumePortfolioDto()
                {
                    Title = "DevOps Board專案管理與Teams整合",
                    Text = "曾經歷Scrum與Board等專案管理策略，以提升團隊運作效率與實現率，並整合Team Webhook通知以即時追蹤與管理",
                    ImgUrl = "/images/azure devops.png",
                    Tags = new List<PortfolioTag>() { PortfolioTag.DevOps }
                },
                new ResumePortfolioDto()
                {
                    Title = "使用Websocket連接Azure Chat Bot與第三方Livechat平台",
                    Text = "使用非同步方法與Websocket將第三方平台與Azure Chat Bot進行即時訊息串接，並應用一套完整的錯誤重試機制",
                    ImgUrl = "/images/chat bot connector.png",
                    Tags = new List<PortfolioTag>() { PortfolioTag.Backend }
                },
                new ResumePortfolioDto()
                {
                    Title = "應用私有化Nuget與Git Submodule實現跨專案共享邏輯",
                    Text = "使用NuPack、Pipeline與Artifact，將共享專案於版控時進行自動化發布，同時也允許使用Submodule將版控模組化，以利不同專案共享邏輯，達到集中控管之目的",
                    ImgUrl = "/images/nupack.png",
                    Tags = new List<PortfolioTag>() { PortfolioTag.Backend }
                },
                new ResumePortfolioDto()
                {
                    Title = "撰寫排程備份檔案於OneDrive",
                    Text = "用排程管理與壓縮檔案，並連接MS Graph API進行檔案定期備份",
                    ImgUrl = "/images/onedrive backup.png",
                    Tags = new List<PortfolioTag>() { PortfolioTag.Backend }
                },
                new ResumePortfolioDto()
                {
                    Title = "網頁資料爬蟲",
                    Text = "將水庫公開資料(降雨量、蓄水量等)進行資料爬蟲，批次蒐集不同日期與地點之資訊。",
                    ImgUrl = "/images/resevior web clawner.png",
                    Tags = new List<PortfolioTag>() { PortfolioTag.Frontend }
                },
                new ResumePortfolioDto()
                {
                    Title = "模擬洪水之水庫控制放流歷線設計",
                    Text = "使用連續方程式，藉由已知水庫入流量與初始水位，模擬颱風歷程時每小時須人工放水之水量，以避免水位過高導致水庫溢滿。模擬須遵守現有規則條件，並使用非線性方程求根以計算下一小時放水量。",
                    ImgUrl = "/images/flood emulator.png",
                    Tags = new List<PortfolioTag>() { PortfolioTag.Backend }
                },
            };
            return dtos;
        }

        public List<ResumeSkillDto> GetSkills()
        {
            var dtos = new List<ResumeSkillDto>()
            {
                new ResumeSkillDto()
                {
                    Type = SkillType.Backend,
                    Skills = new List<string>()
                    {
                        "Visual C#",
                        "Visual Basic",
                        ".net Core",
                        ".net MVC 5",
                        "OOP (物件導向設計)",
                        "AOP (切面導向設計)",
                        "Unit of work (資料層架構)",
                        "Dependency Injection",
                        "Middleware (Global Exception Handler)",
                        "Unit Test (單元測試)",
                        "Restful API (Authentication)",
                        "MS SQL Server (View、Index、PK、Constraint)",
                        "Git & Submodule (版控)",
                        "Websocket & SignalR",
                    }
                },
                new ResumeSkillDto()
                {
                    Type = SkillType.Frontend,
                    Skills = new List<string>()
                    {
                        "React.js (Hook)",
                        "Javascript",
                        "Babel",
                        "Webpack",
                        "NPM",
                        "Razor",
                        "JQuery",
                        "HTML",
                        "CSS",
                    }
                },
                new ResumeSkillDto()
                {
                    Type = SkillType.Tool,
                    Skills = new List<string>()
                    {
                        "Hangfire (排程管理)",
                        "Dapper & Entity Framework (ORM)",
                        "T4 Text Templates",
                        "Visual Studio",
                        "SSIS & Task Scheduler",
                        "SourceTree, TortoiseGit & Fork (版控)",
                        "Github & Markdown",
                        "SonarQube (源碼掃描)",
                        "SSMS (SQL Server)",
                        "Selenium (網頁爬蟲)",
                        "Postman (API)",
                        "Excel 樞紐分析",
                    }
                },
                new ResumeSkillDto()
                {
                    Type = SkillType.Experience,
                    Skills = new List<string>()
                    {
                        "Azure (Bot framework、Blob、App Service、Application Insights)",
                        "Azure DevOps (CI/CD Pipelines自動化部署、Artifact 私有Nuget套件、Board & Agile專案管理)",
                        "Teams Webhook (即時通知)",
                        "Microsoft Graph API (OneDrive)",
                        "Web Hosting (Linux Ubuntu、Windows Server)",
                        "DNS (域名控管)",
                        "Zendesk (客服對話)",
                        "SendGrid (郵件服務)",
                        "Salesforce (客戶關係管理)",
                        "Salesforce Pardot (行銷自動化)",
                    }
                },
            };
            return dtos;
        }

        public List<ResumeTimeLineDto> GetTimeLineItems()
        {
            var dtos = new List<ResumeTimeLineDto>()
            {
                new ResumeTimeLineDto()
                {
                    Year = 2013,
                    Month = "Q4",
                    Title=  "就讀成功大學",
                    Description = "國立成功大學水利及海洋工程學系"
                },
                new ResumeTimeLineDto()
                {
                    Year = 2015,
                    Month = "Q1",
                    Title=  "擔任成大服務團團長",
                    Description = "領導社團並與里長合作將活動帶向社區，並主辦新生板車服務隊協助行李搬運"
                },
                new ResumeTimeLineDto()
                {
                    Year = 2015,
                    Month = "Q4",
                    Title=  "學習Matlab",
                    Description = "初入程式領域，撰寫水庫進出流之洪水模擬程式"
                },
                new ResumeTimeLineDto()
                {
                    Year = 2017,
                    Month = "Q2",
                    Title=  "錄取成大研究所 & 學習R語言",
                    Description = "提前半年進入研究室協助政府計畫，學習R語言進行水庫水文資料之統計分析"
                },
                new ResumeTimeLineDto()
                {
                    Year = 2018,
                    Month = "Q4",
                    Title=  "學習Machine Learning",
                    Description = "將方法導入研究，以R語言進行資料清理、分析、繪圖與預測"
                },
                new ResumeTimeLineDto()
                {
                    Year = 2019,
                    Month = "Q1",
                    Title=  "自學Python & 網頁爬蟲",
                    Description = "以Selenium批次抓取政府公開之水庫資料"
                },
                new ResumeTimeLineDto()
                {
                    Year = 2019,
                    Month = "Q3",
                    Title=  "錄取研華科技 & 學習C# .net MVC",
                    Description = "擔任行銷自動化系統之後端工程師"
                },
                new ResumeTimeLineDto()
                {
                    Year = 2020,
                    Month = "Q1",
                    Title=  "自學React.js",
                    Description = "將前端框架套用到.net專案上，實現one page website"
                },
                new ResumeTimeLineDto()
                {
                    Year = 2021,
                    Month = "Q3",
                    Title=  "晉升高級工程師",
                    Description = "除完成預期開發目標，也大幅改善運作穩定性，2年內即晉升職位"
                },
                                new ResumeTimeLineDto()
                {
                    Year = 2022,
                    Month = "Q1",
                    Title=  "架設個人網站",
                    Description = "租賃Linux VPS架設屬於自己的.net Core網頁"
                },
            };

            dtos = dtos.OrderByDescending(x => x.Month).OrderByDescending(x => x.Year).ToList();
            return dtos;
        }
    }
}
