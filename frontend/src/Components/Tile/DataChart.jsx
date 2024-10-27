import React, { useEffect, useRef } from 'react';

const DataChart = () => {
  const canvasRef = useRef(null);

  useEffect(() => {
    const canvas = canvasRef.current;
    const ctx = canvas.getContext('2d');

    // Data for the chart
    const data = [200, 75, 45];
    const colors = ['#4BC0C0', '#FFCE56', '#FF6384'];
    const labels = ['Approved', 'In Review', 'Rejected'];

    // Calculate total and angles
    const total = data.reduce((acc, value) => acc + value, 0);
    let startAngle = 0;

    // Function to draw pie chart
    data.forEach((value, index) => {
      const sliceAngle = (value / total) * 2 * Math.PI;
      const endAngle = startAngle + sliceAngle;

      // Draw slice
      ctx.beginPath();
      ctx.moveTo(150, 150); // Center of the canvas
      ctx.arc(150, 150, 100, startAngle, endAngle);
      ctx.closePath();
      ctx.fillStyle = colors[index];
      ctx.fill();

      // Draw labels
      const midAngle = startAngle + sliceAngle / 2;
      const labelX = 150 + Math.cos(midAngle) * 120;
      const labelY = 150 + Math.sin(midAngle) * 120;
      ctx.fillStyle = '#000';
      ctx.font = '14px Arial';
      ctx.fillText(labels[index], labelX - 20, labelY);

      // Update start angle for next slice
      startAngle = endAngle;
    });
  }, []);

  return (
    <div>
      <canvas ref={canvasRef} width={300} height={300} />
    </div>
  );
};

export default DataChart;
  