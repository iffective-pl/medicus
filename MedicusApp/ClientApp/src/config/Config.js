import config from './config.json';

function env() {
    switch(window.location.hostname) {
        default:
        case "localhost":
            return "Development"
        case "medicus.iffective.pl":
            return "Preprod"
        case "medicus.wloclawek.pl":
            return "Production"
    }
}

function cfg() {
    switch(env()) {
        default:
        case "Development":
            return config.Development
        case "Preprod":
            return config.Preprod
        case "Production":
            return config.Production
    }
}

const Config = cfg();

export default Config;