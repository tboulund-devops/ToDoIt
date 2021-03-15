pipeline {
    agent any
    stages {
        stage("Build Web") {
            // Will build the website (if needed)
        }
        stage("Build API") {
            // Will build the API project
        }
        stage("Build database") {
            // Will build the database (if using a state-based approach)
        }
        stage("Test API") {
            // Will execute unit tests of the API project
        }
        stage("Deliver Web") {
            // Will deliver the website to Docker Hub
        }
        stage("Deliver API") {
            // Will deliver the API to Docker Hub
        }
        stage("Release staging environment") {
            // Will use Docker Compose to spin up a test environment.
        }
        stage("Automated acceptance test") {
            // Will use Selenium to execute automatic acceptance tests.
        }
    }
}