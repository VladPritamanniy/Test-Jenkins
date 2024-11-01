import { useRouteError } from "react-router-dom";
import styles from './Error.module.scss';

interface RouteError {
    statusText?: string;
    message?: string;
}

export default function Error() {
    const error = useRouteError() as RouteError;

    return (
        <div className={styles.errorPage}>
            <h1>Oops!</h1>
            <p>Sorry, an unexpected error has occurred.</p>
            <p>
                <i>{error.statusText || error.message}</i>
            </p>
        </div>
    );
}