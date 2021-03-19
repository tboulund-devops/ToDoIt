pipeline {
    agent any
	triggers {
		cron 'H * * * *'
		pollSCM 'H/3 * * * *'
	}
    stages {
        stage("Build Web") {
            steps {
                sh "dotnet build src/WebUI/WebUI.csproj"
            }
        }
        stage("Build API") {
            steps {
                sh "dotnet build src/API/API.csproj"
            }
        }
        stage("Build database") {
            steps {
                echo "===== OPTIONAL: Will build the database (if using a state-based approach) ====="
            }
        }
        stage("Test API") {
            steps {
                sh "dotnet test test/UnitTest/UnitTest.csproj"
            }
        }
        stage("Deliver Web") {
            steps {
                steps
				{
					sh "docker build . -t gruppe1devops/todoit-webui"
					withCredentials([[$class: 'UsernamePasswordMultiBinding', credentialsId: 'DockerID', usernameVariable: 'USERNAME', passwordVariable: 'PASSWORD']])
					{
						sh 'docker login -u ${USERNAME} -p ${PASSWORD}'
					}
					sh "docker push gruppe1devops/todoit-webui"
				}
            }
        }
        stage("Deliver API") {
            steps {
                steps
				{
					sh "docker build . -t gruppe1devops/todoit-webapi"
					withCredentials([[$class: 'UsernamePasswordMultiBinding', credentialsId: 'DockerID', usernameVariable: 'USERNAME', passwordVariable: 'PASSWORD']])
					{
						sh 'docker login -u ${USERNAME} -p ${PASSWORD}'
					}
					sh "docker push gruppe1devops/todoit-webapi"
				}
            }
        }
        stage("Release staging environment") {
            steps {
                echo "===== REQUIRED: Will use Docker Compose to spin up a test environment ====="
            }
        }
        stage("Automated acceptance test") {
            steps {
                echo "===== REQUIRED: Will use Selenium to execute automatic acceptance tests ====="
            }
        }
    }
}