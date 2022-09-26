import dotenv from 'dotenv';
import dotenvExpand from 'dotenv-expand';
import config from './config.json';

const env = dotenv.config();
dotenvExpand.expand(env);

function cfg() {
    console.log(env)
    switch(process.env.NODE_ENV) {
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