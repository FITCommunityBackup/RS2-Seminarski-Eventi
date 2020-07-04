﻿using Microsoft.EntityFrameworkCore;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EventiApplication.WebAPI.Database
{
    public static class DataInit
    {
        public static void DopunaSlike(MojContext _ctx)
        {
            List<Event> eventi = _ctx.Event.Include(e => e.Kategorija).ToList();

            if(eventi!= null && eventi.Count>0)
            {
                foreach (var e in eventi)
                {
                    if (e.Slika == null)
                    {
                        if (e.Kategorija.Naziv == "Muzika")
                        {
                            e.Slika = Helper.ImageHelper.ReadFile("./Images/koncert.jpg");
                            e.SlikaThumb = Helper.ImageHelper.ReadFile("./Images/koncert.jpg");
                        }
                        else if (e.Kategorija.Naziv == "Kultura")
                        {
                            e.Slika = Helper.ImageHelper.ReadFile("./Images/opera.jpg");
                            e.SlikaThumb = Helper.ImageHelper.ReadFile("./Images/opera.jpg");
                        }
                        else
                        {
                            e.Slika = Helper.ImageHelper.ReadFile("./Images/fudbal.jpg");
                            e.SlikaThumb = Helper.ImageHelper.ReadFile("./Images/fudbal.jpg");
                        }

                        _ctx.SaveChanges();
                    }
                }
            }

            var karte = _ctx.Karta.Include(k=>k.KupovinaTip).Include(k=>k.KupovinaTip.Kupovina).ToList();
            if(karte!=null && karte.Count > 0)
            {
                foreach(var k in karte)
                {
                    Database.Korisnik korisnik = _ctx.Korisnik.Find(k.KupovinaTip.Kupovina.KorisnikId);

                    Database.Event Event = _ctx.Event.Find(k.KupovinaTip.Kupovina.EventId);

                    if (korisnik == null || Event == null)
                        return;

                    QRCodeGenerator qr = new QRCodeGenerator();
                    string text = Event.Id.ToString() + " - " + Event.Naziv + " - Broj karte: " + k.Id + " - KorsnikId: " + korisnik.Id;
                    QRCodeData data = qr.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
                    QRCode qRCode = new QRCode(data);

                    Bitmap qrCodeImage = qRCode.GetGraphic(20);

                    MemoryStream ms = new MemoryStream();

                    qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                    byte[] imageBytes = ms.ToArray();
                    k.QrCode = imageBytes;

                    _ctx.SaveChanges();
                }
            }
        }
    }
}
