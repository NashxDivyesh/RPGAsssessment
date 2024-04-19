[![CI Build](https://github.com/NashxDivyesh/RPGAsssessment/actions/workflows/ci.yaml/badge.svg?branch=main)](https://github.com/NashxDivyesh/RPGAsssessment/actions/workflows/ci.yaml)
# RPGAsssessment

### To build the project

`dotnet build ./RPG.sln`

### To generate TestResults

`dotnet test RPG.sln /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=../../TestResults/lcov.info --logger "trx;LogFileName=test-results.trx" --results-directory "TestResults"`

### To generate code coverage reports in HTML

`reportgenerator -reports:TestResults/**/lcov.info -targetdir:TestResults/HtmlReport`

# You can access Code Coverage report [here](https://nashxdivyesh.github.io/RPGAsssessment/)

[<img src="test-coverage-report.png">](https://nashxdivyesh.github.io/RPGAsssessment/)

# GitHub Actions

1. CI pipeline to build and test solution with test report on each run - [Click here](https://github.com/NashxDivyesh/RPGAsssessment/actions/runs/8757050222/job/24034898473)
2. Deploy generated report to GitHub Pages - https://nashxdivyesh.github.io/RPGAsssessment/)
