'use client'
import { useEffect, useState } from "react";
import Header from "./components/header";
import "./globals.css";
import { check } from "./services/auth";
import { usePathname, useRouter } from "next/navigation";

export default function RootLayout({ children }) {
    const router = useRouter();
    const pathName = usePathname();

    const handleCheckAuth = async () => {
        const response = await check();

        if (!response.ok && pathName != "/register" && pathName != "/login") {
              router.push("/login"); 
              return false;
        } 

        return true;
    };

    useEffect(() => {
        if (!handleCheckAuth()) {
            window.location.reload(); 
        }
    }, [pathName]);

    return (
        <html lang="en">
            <body>
                <Header />
                {children}
            </body>
        </html>
    );
}