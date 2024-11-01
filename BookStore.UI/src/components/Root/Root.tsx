import { Outlet } from "react-router-dom";
import styles from './Root.module.scss';

export default function App() {
  return (
    <>
      <div className={styles.header}>
        <img src='/book.png' />
        <h1>Books</h1>
      </div>
      <Outlet />
    </>
  )
}
