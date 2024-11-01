import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import Root from '../Root/Root.tsx'
import Home from '../../pages/Home/Home.tsx';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import Error from '../../pages/Error/Error.tsx';
import Create, { action as createBookAction } from '../../pages/Create/Create.tsx';

export const router = createBrowserRouter([{
  path: "/",
  element: <Root />,
  errorElement: <Error />,
  children: [
    {
      index: true,
      path: "/",
      element: <Home />
    },
    {
      path: "/create",
      element: <Create />,
      action: createBookAction
    },
  ]
}]);

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <RouterProvider router={router} />
  </StrictMode>
)
