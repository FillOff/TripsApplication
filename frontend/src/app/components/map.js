'use client';

import { useEffect, useRef } from "react";
import L from "leaflet";
import "leaflet/dist/leaflet.css";
import "leaflet-routing-machine/dist/leaflet-routing-machine.css";
import "leaflet-routing-machine";

export async function geocode(city) {
    try {
        const response = await fetch(
            `https://nominatim.openstreetmap.org/search?city=${city}&format=json&addressdetails=1&limit=1`
        );
        const data = await response.json();
        if (data && data[0]) {
            return [parseFloat(data[0].lat), parseFloat(data[0].lon)];
        } else {
            throw new Error(`Город "${city}" не найден.`);
        }
    } catch (error) {
        console.error("Ошибка геокодирования:", error);
        throw error;
    }
}

export default function Map({ startPlace, endPlace, setLength, setDuration }) {
    const mapRef = useRef(null);
    const mapInstance = useRef(null);
    const routingControl = useRef(null);

    async function buildRoute(startPlace, endPlace) {
        if (!startPlace || !endPlace) return;
        try {
            const [startLat, startLon] = await geocode(startPlace);
            const [endLat, endLon] = await geocode(endPlace);
            
            if (routingControl.current) {
                mapInstance.current.removeControl(routingControl.current);
            }
            
            routingControl.current = L.Routing.control({
                waypoints: [
                    L.latLng(startLat, startLon),
                    L.latLng(endLat, endLon)
                ],
                routeWhileDragging: true,
                showAlternatives: false,
                addWaypoints: false,
                createMarker: () => null
            }).addTo(mapInstance.current);

            routingControl.current.on('routesfound', function (e) {
                const route = e.routes[0];
                setLength((route.summary.totalDistance / 1000).toFixed(2));
                setDuration(route.summary.totalTime);
            });
        } catch (error) {
            console.error("Ошибка построения маршрута:", error);
            alert(error.message);
        }
    }

    useEffect(() => {
        if (!mapInstance.current && mapRef.current) {
            mapInstance.current = L.map(mapRef.current).setView([53.9045, 27.5615], 6);

            L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
                attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
            }).addTo(mapInstance.current);
        }
    }, []);

    useEffect(() => {
        const fetchAndBuildRoute = async () => {
            if (mapInstance.current && startPlace && endPlace) {
                await buildRoute(startPlace, endPlace);
            }
        };
        
        fetchAndBuildRoute();
    }, [startPlace, endPlace]);

    return (
        <div>
            <div id="map" ref={mapRef} className="h-[500px] mt-4 z-0" />
        </div>
    );
}